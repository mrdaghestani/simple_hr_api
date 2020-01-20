using Xunit;
using System;

namespace FSHR.Models.Tests
{
    public class UserTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            var instance = new Models.User(1, "username", password);

            Assert.Equal(1, instance.Id);
            Assert.Equal("username", instance.Username);
            Assert.Equal(password, instance.Password);
            Assert.Equal(DateTime.Now, instance.CreationTime, TimeSpan.FromMilliseconds(200));
        }
    }
}