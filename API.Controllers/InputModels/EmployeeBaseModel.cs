using EmployeeBase.BLL.Enums;

namespace EmployeeBase.Controllers.InputModels
{
    public class EmployeeBaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public string Information { get; set; }
        public Department Department { get; set; }
    }
}
