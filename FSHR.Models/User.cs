namespace FSHR.Models
{
    public class User
    {
        public User(int id, string username, Password password)
        {
            Id = id;
            Username = username;
            Password = password;
            CreationTime = System.DateTime.Now;
        }
        public int Id { get; private set; }
        public string Username { get; private set; }
        public Password Password { get; private set; }
        public System.DateTime CreationTime { get; private set; }
        public int? EmployeeId { get; private set; }

        public void SetEmployee(Employee employee)
        {
            EmployeeId = employee.Id;
        }
    }
}