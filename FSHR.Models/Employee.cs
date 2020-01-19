
namespace FSHR.Models
{
    public class Employee
    {
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsEnabled = true;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsEnabled { get; private set; }
    }
}