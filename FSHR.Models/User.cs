using FSHR.Common;
using FSHR.Models.Exceptions;

namespace FSHR.Models
{
    public class User : IModel<int>
    {
        public User(int id, string firstName, string lastName, Gender gender, string mobileNumber, string emailAddress, Password password)
        {
            if (ValidationHelpers.IsEmpty(firstName)) throw new InvalidArgument(nameof(firstName));
            if (ValidationHelpers.IsEmpty(lastName)) throw new InvalidArgument(nameof(lastName));
            if (ValidationHelpers.IsEmpty(mobileNumber)) throw new InvalidArgument(nameof(mobileNumber));
            if (ValidationHelpers.IsEmpty(emailAddress)) throw new InvalidArgument(nameof(emailAddress));

            if (!ValidationHelpers.IsNumeric(mobileNumber)) throw new InvalidArgument(nameof(mobileNumber));
            if (!ValidationHelpers.IsEmail(emailAddress)) throw new InvalidArgument(nameof(emailAddress));

            if (mobileNumber.Length != 11) throw new InvalidArgument(nameof(mobileNumber));

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
            Password = password;
            CreationTime = System.DateTime.Now;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MobileNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public Gender Gender { get; private set; }
        public Password Password { get; private set; }
        public System.DateTime CreationTime { get; private set; }
    }
}