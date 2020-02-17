namespace FSHR.Services
{
    public interface IRandomGenerator : IAppService
    {
        string GetCombinedLettersAndDigits(int length);
    }
}