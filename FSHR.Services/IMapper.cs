namespace FSHR.Services
{
    public interface IMapper : IAppService
    {
        Models.Gender ToModel(DTOs.Gender dto);
    }
}