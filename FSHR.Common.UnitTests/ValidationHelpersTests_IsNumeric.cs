using Xunit;
using System;

namespace FSHR.Common.UnitTests
{
    public class ValidationHelpersTests_IsNumeric
    {
        [Fact]
        public void IsNumeric_should_return_true_for_numbers()
        {
            Assert.True(ValidationHelpers.IsNumeric("8765"));
        }
        [Fact]
        public void IsNumeric_should_return_true_for_one_number()
        {
            Assert.True(ValidationHelpers.IsNumeric("8"));
        }
        [Fact]
        public void IsNumeric_should_return_false_for_letters()
        {
            Assert.False(ValidationHelpers.IsNumeric("fIss"));
        }
        [Fact]
        public void IsNumeric_should_return_false_for_one_letter()
        {
            Assert.False(ValidationHelpers.IsNumeric("Q"));
        }
        [Fact]
        public void IsNumeric_should_return_false_for_combination_of_letters_and_numbers()
        {
            Assert.False(ValidationHelpers.IsNumeric("234Q432"));
        }
        [Fact]
        public void IsNumeric_should_return_false_for_special_characters()
        {
            Assert.False(ValidationHelpers.IsNumeric("*&^"));
        }
        [Fact]
        public void IsNumeric_should_return_false_for_space()
        {
            Assert.False(ValidationHelpers.IsNumeric("  "));
        }
        [Fact]
        public void IsNumeric_should_return_true_for_empty_string()
        {
            Assert.True(ValidationHelpers.IsNumeric(""));
        }
    }
}