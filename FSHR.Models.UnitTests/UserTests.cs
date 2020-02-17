using Xunit;
using System;

namespace FSHR.Models.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            var instance = new Models.User(1, "first", "last", Gender.Unknown, "12345678901", "t@t.t", password);

            Assert.Equal(1, instance.Id);
            Assert.Equal("first", instance.FirstName);
            Assert.Equal("last", instance.LastName);
            Assert.Equal(Gender.Unknown, instance.Gender);
            Assert.Equal("12345678901", instance.MobileNumber);
            Assert.Equal("t@t.t", instance.EmailAddress);
            Assert.Equal(password, instance.Password);
            Assert.Equal(DateTime.Now, instance.CreationTime, TimeSpan.FromMilliseconds(200));
        }
        [Fact]
        public void Constructor_should_throw_when_firstname_is_empty()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "", "last", Gender.Unknown, "12345678901", "t@t.t", password));
        }
        [Fact]
        public void Constructor_should_throw_when_lastname_is_empty()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "", Gender.Unknown, "12345678901", "t@t.t", password));
        }
        [Fact]
        public void Constructor_should_throw_when_mobile_is_empty()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "", "t@t.t", password));
        }
        [Fact]
        public void Constructor_should_throw_when_email_is_empty()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "12345678901", "", password));
        }
        [Fact]
        public void Constructor_should_throw_when_mobile_is_not_numbers()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "mobile", "t@t.t", password));
        }
        [Fact]
        public void Constructor_should_throw_when_mobile_length_is_not_eleven()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "0912", "t@t.t", password));
            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "1234567890123", "t@t.t", password));
        }
        [Fact]
        public void Constructor_should_throw_when_email_is_not_valid()
        {
            var password = Helpers.ReadOnlyInstances.Password;

            Assert.Throws<Models.Exceptions.InvalidArgument>(() => new Models.User(1, "first", "last", Gender.Unknown, "12345678901", "t@t", password));
        }
    }
}