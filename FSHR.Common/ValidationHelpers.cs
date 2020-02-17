using System.Text.RegularExpressions;

namespace FSHR.Common
{
    public class ValidationHelpers
    {
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^\d*$");
        }
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}