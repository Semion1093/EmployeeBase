using EmployeeBase.BLL.Enums;

namespace EmployeeBase.Controllers.InputModels
{
    public class EmployeeInputModel : EmployeeBaseModel
    {
        public Position Position { get; set; }
    }
}
