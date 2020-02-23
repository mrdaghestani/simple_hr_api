using System.Threading.Tasks;
using FSHR.Services.DTOs;
using FSHR.Services.Repositories;

namespace FSHR.Services.Implementations
{
    public class UserService : IUserService
    {
        private const int DefaultPasswordLength = 8;
        private IUserRepository _userRepository;
        private IRandomGenerator _randomGenerator;
        private IMapper _mapper;

        public UserService(
            IUserRepository userRepository
        , IRandomGenerator randomGenerator
        , IMapper mapper)
        {
            _userRepository = userRepository;
            _randomGenerator = randomGenerator;
            _mapper = mapper;
        }
        public async Task<UserRegisterResultDto> Register(UserRegisterDto dto)
        {
            var id = await _userRepository.GetNextKey();
            var password = _randomGenerator.GetCombinedLettersAndDigits(DefaultPasswordLength);

            var passwordModel = new Models.Password(password);

            var user = new Models.User(id, dto.FirstName, dto.LastName, _mapper.ToModel(dto.Gender), dto.MobileNumber, dto.EmailAddress, passwordModel);

            await _userRepository.Create(user);

            Hangfire.BackgroundJob.Enqueue<IEmailService>(x => x.Send(new EmailSendDto
            {
                Body = $"Your FirstSource Password: {password}",
                EmailAddress = dto.EmailAddress,
                Subject = "FirstSource Password"
            }));

            return new UserRegisterResultDto();
        }
    }
}