using EmployeeBase.BLL.Enums;

namespace EmployeeBase.BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public Position Position { get; set; }
        public Department Department { get; set; }
    }
}
