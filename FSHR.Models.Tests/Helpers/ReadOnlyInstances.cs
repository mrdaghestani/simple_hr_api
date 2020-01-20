namespace FSHR.Models.Tests.Helpers
{
    public class ReadOnlyInstances
    {
        internal static readonly Models.User User = new Models.User(1, "username", Password);
        internal static readonly Models.Password Password = new Models.Password("pass", "salt");
    }
}