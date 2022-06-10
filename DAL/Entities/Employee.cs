using EmployeeBase.BLL.Enums;

namespace EmployeeBase.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public string Information { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
        public bool IsDeleted { get; set; }
    }
}