using System;
using Xunit;
using Moq;
using FSHR.Services.Repositories;
using FSHR.Models;
using System.Threading.Tasks;
using System.Linq;

namespace FSHR.Services.UnitTests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Register_should_call_user_repository()
        {
            var randomGenerator = new Implementations.RandomGenerator();
            var mapper = new Implementations.Mapper();

            var mockUserRepository = new Mock<IUserRepository>();

            var userService = new FSHR.Services.Implementations.UserService(mockUserRepository.Object, randomGenerator, mapper);

            var dto = new Services.DTOs.UserRegisterDto
            {
                FirstName = "first",
                LastName = "last",
                Gender = DTOs.Gender.Unknown,
                MobileNumber = "12345678901",
                EmailAddress = "t@t.t"
            };

            var user = new Models.User(1, "first", "last", Gender.Unknown, "12345678901", "t@t.t", new Models.Password("pass"));

            mockUserRepository.Setup(x => x.Create(user)).Returns(new Task(() => { }));
            mockUserRepository.Setup(x => x.GetNextKey()).ReturnsAsync(1);

            await userService.Register(dto);

            mockUserRepository.Verify(repo => repo.GetNextKey(), Times.Once());
            mockUserRepository.Verify(repo => repo.Create((Models.User)mockUserRepository.Invocations.Last().Arguments[0]), Times.Once());
        }
    }
}
