using Xunit;
using FSHR.Models;

namespace FSHR.Models.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var instance = new Models.Password("password", "salt");

            Assert.Equal("salt", instance.Salt);
            Assert.Equal("password", instance.Value);
        }

        [Fact]
        public void Equality_should_return_true_for_same_value_and_password_but_different_instance()
        {
            var password = "pass";
            var salt = "salt";

            var instance1 = new Models.Password(password, salt);
            var instance2 = new Models.Password(password, salt);

            Assert.StrictEqual(instance1, instance2);
            Assert.True(instance1 == instance2);
        }

        [Fact]
        public void Equality_should_return_false_for_comparing_with_null_instance()
        {
            var instance1 = Helpers.ReadOnlyInstances.Password;
            var instance2 = (Models.Password)null;

            Assert.NotStrictEqual(instance1, instance2);
            Assert.False(instance1 == instance2);
        }

        [Fact]
        public void Equality_should_return_false_for_comparing_according_to_casesensitivity()
        {
            var instance1 = new Models.Password("password", "salt");
            var instance2 = new Models.Password("pAssword", "salt");

            Assert.NotStrictEqual(instance1, instance2);
            Assert.False(instance1 == instance2);
        }
    }
}