using Xunit;
using System;

namespace FSHR.Common.UnitTests
{
    public class ValidationHelpersTests_IsEmail
    {
        [Fact]
        public void IsEmail_should_return_true_for_valid_emails()
        {
            Assert.True(ValidationHelpers.IsEmail("test@test.com"));
            Assert.True(ValidationHelpers.IsEmail("t@t.t"));
            Assert.True(ValidationHelpers.IsEmail("t_3.ff@t.t"));
            Assert.True(ValidationHelpers.IsEmail("3.t_3.ff@t.t"));
        }
        [Fact]
        public void IsEmail_should_return_false_for_invalid_emails()
        {
            Assert.False(ValidationHelpers.IsEmail("email"));
            Assert.False(ValidationHelpers.IsEmail("34567"));
            Assert.False(ValidationHelpers.IsEmail("34567@"));
            Assert.False(ValidationHelpers.IsEmail("eiywr@"));
            Assert.False(ValidationHelpers.IsEmail("eiywr@fhjs"));
            Assert.False(ValidationHelpers.IsEmail("eiywr@fhjs."));
        }
    }
}