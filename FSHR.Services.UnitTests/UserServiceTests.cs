using System;
using Xunit;
using Moq;
using FSHR.Services.Repositories;
using FSHR.Models;

namespace FSHR.Services.UnitTests
{
    public class UserServiceTests
    {
        [Fact]
        public void Register_should_call_user_repository()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new FSHR.Services.Implementations.UserService(mockUserRepository.Object);

            var dto = new Services.DTOs.UserRegisterDto();

            userService.Register(dto);

            var user = new Models.User(1, "", new Models.Password("", ""));

            mockUserRepository.Verify(repo => repo.Create(user), Times.Once());
        }
    }
}
