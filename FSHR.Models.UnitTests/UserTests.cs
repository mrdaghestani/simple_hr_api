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

            var instance = new Models.User(1, "username", password);

            Assert.Equal(1, instance.Id);
            Assert.Equal("username", instance.Username);
            Assert.Equal(password, instance.Password);
            Assert.Equal(null, instance.EmployeeId);
            Assert.Equal(DateTime.Now, instance.CreationTime, TimeSpan.FromMilliseconds(200));
        }
        [Fact]
        public void SetEmployee_should_assign_employee_id()
        {
            var user = Helpers.ReadOnlyInstances.User;
            var employee = Helpers.ReadOnlyInstances.Employee;

            user.SetEmployee(employee);

            Assert.Equal(employee.Id, user.EmployeeId);
        }
    }
}