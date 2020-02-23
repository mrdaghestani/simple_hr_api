using System.ComponentModel.DataAnnotations;

namespace FSHR.Services.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [RegularExpression(@"^09\d{9}$")]
        [MaxLength(11)]
        [MinLength(11)]
        public string MobileNumber { get; set; }
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(firstsource.io){1})\Z")]
        public string EmailAddress { get; set; }
    }
}