using System;
using Xunit;
using Moq;
using FSHR.Services.Repositories;
using FSHR.Models;

namespace FSHR.Services.UnitTests
{
    public class MapperTests
    {
        [Fact]
        public void ToModel_gender_mapping_should_return_correct_gender()
        {
            var mapper = new Implementations.Mapper();

            Assert.Equal(Models.Gender.Unknown, mapper.ToModel(DTOs.Gender.Unknown));
        }
    }
}
