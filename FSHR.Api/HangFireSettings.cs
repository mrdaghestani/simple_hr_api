using Hangfire.Mongo;

namespace FSHR.Api
{
    public class HangFireSettings
    {
        public string ConnectionString { get; set; }
        public int WorkerCount { get; set; }
        public MongoMigrationStrategy MongoMigrationStrategy { get; set; }
    }
}