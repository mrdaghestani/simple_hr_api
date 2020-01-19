using Xunit;
using FSHR.Models;

namespace FSHR.Models.Tests
{
    public class UserTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var instance = new Models.User();
        }
    }
}