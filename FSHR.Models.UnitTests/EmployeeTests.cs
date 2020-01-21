using System;
using Xunit;
using FSHR.Models;

namespace FSHR.Models.UnitTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Constructor_should_assign_properties_correctly()
        {
            var instance = new Models.Employee(1, "MohammadReza", "Daghestani");

            Assert.Equal(1, instance.Id);
            Assert.Equal("MohammadReza", instance.FirstName);
            Assert.Equal("Daghestani", instance.LastName);
            Assert.True(instance.IsEnabled, "Employee should be enabled after creation.");
        }
    }
}
