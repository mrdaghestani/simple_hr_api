using Xunit;
using System;

namespace FSHR.Common.UnitTests
{
    public class ValidationHelpersTests_IsEmpty
    {
        [Fact]
        public void IsEmpty_should_return_true_for_null()
        {
            Assert.True(ValidationHelpers.IsEmpty(null));
        }
        [Fact]
        public void IsEmpty_should_return_true_for_empty_string()
        {
            Assert.True(ValidationHelpers.IsEmpty(""));
        }
        [Fact]
        public void IsEmpty_should_return_true_for_spaces()
        {
            Assert.True(ValidationHelpers.IsEmpty("  "));
        }
    }
}