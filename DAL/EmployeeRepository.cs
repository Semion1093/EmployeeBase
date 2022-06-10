using AutoMapper;
using EmployeeBase.BLL.Enums;
using EmployeeBase.BLL.Models;
using EmployeeBase.BLL.Services.Interfaces;
using EmployeeBase.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBase.DAL
{  
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmloyeeBaseContext _context;
        private IMapper _mapper;

        public EmployeeRepository(EmloyeeBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            var addedEmployee = _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return addedEmployee.Entity.Id;
        }

        public async Task DeleteEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<EmployeeModel>(employeeModel);
            _context.Entry(new Employee { Id = employee.Id, IsDeleted = true })
                .Property(x => x.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _context.Employees
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(employees);
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<EmployeeModel>(employee);
        }

        public async Task<List<EmployeeModel>> GetEmployeesByDepartment(Department department)
        {
            var employees = await _context.Employees
                .Where(x => x.Department == department)
                .ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(employees);
        }

        public async Task<List<EmployeeModel>> GetEmployeesByPosition(Position position)
        {
            var employees = await _context.Employees
                .Where(x => x.Position == position)
                .ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(employees);
        }

        public async Task PromoteEmloyee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<EmployeeModel>(employeeModel);
            _context.Entry(new Employee { Id = employee.Id, Position = employee.Position })
                .Property(x => x.Position).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
