using Xunit;
using FSHR.Models;
using System;

namespace FSHR.Models.UnitTests
{
    public class PasswordTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var instance = new Models.Password("pass");

            Assert.NotEmpty(instance.Salt);
            Assert.NotEmpty(instance.Hash);
            Assert.True(instance.HashByteSize > 0);
            Assert.True(instance.HasingIterationCount > 0);
            Assert.Equal(DateTime.Now, instance.GenerationTime, TimeSpan.FromMilliseconds(200));
        }

        [Fact]
        public void IsMatch_should_return_true_for_same_password()
        {
            var password = "my-pass-123";

            var instance = new Models.Password(password);

            Assert.True(instance.IsMatch(password));
        }

        [Fact]
        public void IsMatch_should_return_false_for_same_password_but_different_case_sesitivity()
        {
            var password = "my-pass-123";

            var instance = new Models.Password(password);

            Assert.False(instance.IsMatch("my-Pass-123"));
        }
        [Fact]
        public void IsMatch_should_return_false_for_different_password()
        {
            var password = "my-pass-123";

            var instance = new Models.Password(password);

            Assert.False(instance.IsMatch("my-p"));
        }
    }
}