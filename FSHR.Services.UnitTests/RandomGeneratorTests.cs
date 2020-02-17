using System;
using Xunit;
using Moq;
using FSHR.Services.Repositories;
using FSHR.Models;

namespace FSHR.Services.UnitTests
{
    public class RandomGeneratorTests
    {
        [Fact]
        public void GetCombinedLettersAndDigits_should_return_correct_generated_string_length()
        {
            var generator = new Implementations.RandomGenerator();

            Assert.Equal(8, generator.GetCombinedLettersAndDigits(8).Length);
        }
    }
}
