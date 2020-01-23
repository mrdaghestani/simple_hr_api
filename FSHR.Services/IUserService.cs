using System.Threading.Tasks;

namespace FSHR.Services
{
    public interface IUserService : IAppService
    {
        Task<DTOs.UserRegisterResultDto> Register(DTOs.UserRegisterDto dto);
    }
}