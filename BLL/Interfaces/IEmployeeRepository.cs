using EmployeeBase.BLL.Enums;
using EmployeeBase.BLL.Models;

namespace EmployeeBase.BLL.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployee(EmployeeModel employeeModel);
        Task DeleteEmployee(EmployeeModel employeeModel);
        Task UpdateEmployee(EmployeeModel employeeModel);
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<List<EmployeeModel>> GetAllEmployees();
        Task PromoteEmloyee(EmployeeModel employeeModel);
        Task<List<EmployeeModel>> GetEmployeesByPosition(Position position);
        Task<List<EmployeeModel>> GetEmployeesByDepartment(Department department);
    }
}
