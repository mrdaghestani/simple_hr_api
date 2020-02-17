namespace FSHR.Models.UnitTests.Helpers
{
    public class ReadOnlyInstances
    {
        internal static readonly Models.User User = new Models.User(1, "first", "last", Gender.Unknown, "12345678901", "t@t.t", Password);
        internal static readonly Models.Password Password = new Models.Password("pass");
    }
}