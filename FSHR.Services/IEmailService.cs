using System.Threading.Tasks;

namespace FSHR.Services
{
    public interface IEmailService : IAppService
    {
        Task<DTOs.EmailSendResultDto> Send(DTOs.EmailSendDto dto);
    }
}