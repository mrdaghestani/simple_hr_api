using System.Threading.Tasks;
using FSHR.Services.DTOs;
using FSHR.Services.Repositories;

namespace FSHR.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserRegisterResultDto> Register(UserRegisterDto dto)
        {
            return Task.FromResult((UserRegisterResultDto)null);
        }
    }
}