namespace FSHR.Services.DTOs
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}