using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Hangfire;
using Hangfire.Mongo;

namespace FSHR.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //registering services
            services.AddScoped<FSHR.Services.IMapper, FSHR.Services.Implementations.Mapper>();
            services.AddScoped<FSHR.Services.IRandomGenerator, FSHR.Services.Implementations.RandomGenerator>();
            services.AddScoped<FSHR.Services.IUserService, FSHR.Services.Implementations.UserService>();


            //registering repositories
            services.AddScoped<FSHR.Services.Repositories.IUserRepository, FSHR.Mongo.UserRepository>();


            //register settings
            services.Configure<FSHR.Mongo.MongoDatabaseSettings>(Configuration.GetSection(nameof(FSHR.Mongo.MongoDatabaseSettings)));
            services.AddSingleton<FSHR.Mongo.IMongoDatabaseSettings>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<FSHR.Mongo.MongoDatabaseSettings>>().Value;
                var env = sp.GetRequiredService<IHostingEnvironment>();
                if (env.IsEnvironment("Integration"))
                {
                    var random = sp.GetRequiredService<FSHR.Services.IRandomGenerator>();
                    settings.DatabaseName = $"test_{random.GetCombinedLettersAndDigits(10)}";
                }
                return settings;
            });


            // Add Hangfire services.
            services.Configure<HangFireSettings>(Configuration.GetSection(nameof(HangFireSettings)));
            var hangfireSettings = services.BuildServiceProvider().GetRequiredService<IOptions<HangFireSettings>>().Value;

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(hangfireSettings.ConnectionString, new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions(hangfireSettings.MongoMigrationStrategy)
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer(options =>
            {
                options.WorkerCount = hangfireSettings.WorkerCount;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHangfireDashboard();

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
