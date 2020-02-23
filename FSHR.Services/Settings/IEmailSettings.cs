namespace FSHR.Services.Settings
{
    public interface IEmailSettings
    {
        string Host { get; }
        string Username { get; }
        string Password { get; }
        string From { get; }
        int Port { get; }
        bool EnableSsl { get; }
        bool UseDefaultCredentials { get; }
    }
}