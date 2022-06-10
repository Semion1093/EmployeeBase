using EmployeeBase.BLL.Enums;
using EmployeeBase.BLL.Models;
using EmployeeBase.BLL.Services.Interfaces;

namespace EmployeeBase.BLL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddEmployee(EmployeeModel employeeModel)
        {
            var employeeId = await _employeeRepository.AddEmployee(employeeModel);

            return employeeId;
        }

        public async Task DeleteEmployee(EmployeeModel employeeModel)
        {
            await _employeeRepository.DeleteEmployee(employeeModel);
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();

            return employees;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            return employee;
        }

        public async Task<List<EmployeeModel>> GetEmployeesByDepartment(Department department)
        {
            var employees = await _employeeRepository.GetEmployeesByDepartment(department);

            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeesByPosition(Position position)
        {
            var employees = await _employeeRepository.GetEmployeesByPosition(position);

            return employees;
        }

        public async Task PromoteEmloyee(EmployeeModel employeeModel)
        {
            await _employeeRepository.PromoteEmloyee(employeeModel);
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            await _employeeRepository.UpdateEmployee(employeeModel);
        }
    }
}
