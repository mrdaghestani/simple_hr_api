
namespace FSHR.Services.Implementations
{
    public class Mapper : IMapper
    {
        public Models.Gender ToModel(DTOs.Gender dto)
        {
            return (Models.Gender)dto;
        }
    }
}