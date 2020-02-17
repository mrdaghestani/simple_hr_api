using Xunit;
using System;

namespace FSHR.Common.UnitTests
{
    public class ExceptionBaseTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var actualMessageParams = new[] { "val1", "val2" };
            var actualInnerException = new Exception();

            var instance = new Mock.ExceptionBaseMock(1, 404, "msg", actualMessageParams, actualInnerException);

            Assert.Equal(1, instance.Code);
            Assert.Equal(404, instance.HttpStatusCode);
            Assert.Equal("msg", instance.Message);
            Assert.Equal(actualMessageParams, instance.MessageParams);
            Assert.Equal(actualInnerException, instance.InnerException);
        }
    }
}