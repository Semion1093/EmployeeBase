using EmployeeBase.Controllers.InputModels;
using AutoMapper;
using EmployeeBase.BLL.Enums;
using EmployeeBase.BLL.Models;
using EmployeeBase.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeBase.Controllers.OutputModels;

namespace EmployeeBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeInputModel employeeInputModel)
        {
            var employeeId = await _employeeService.AddEmployee(_mapper.Map<EmployeeModel>(employeeInputModel));

            return StatusCode(StatusCodes.Status201Created, employeeId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeOutputModel>> GetEmployeeById(int id)
        {
            var employee = _mapper.Map<EmployeeOutputModel>(await _employeeService.GetEmployeeById(id));

            return employee;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeOutputModel>>> GetAllEmployees()
        {
            var employees = _mapper.Map<List<EmployeeOutputModel>>(await _employeeService.GetAllEmployees());

            return employees;
        }

        [HttpGet("by-position")]
        public async Task<ActionResult<List<EmployeeOutputModel>>> GetAllEmployeesByPosition(Position position)
        {
            var employees = _mapper.Map<List<EmployeeOutputModel>>(await _employeeService.GetEmployeesByPosition(position));

            return employees;
        }

        [HttpGet("by-department")]
        public async Task<ActionResult<List<EmployeeOutputModel>>> GetAllEmployeesByDepartment(Department department)
        {
            var employees = _mapper.Map<List<EmployeeOutputModel>>(await _employeeService.GetEmployeesByDepartment(department));

            return employees;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeUpdateModel employeeUpdateModel)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(employeeUpdateModel);
            await _employeeService.UpdateEmployee(employeeModel);

            return NoContent();
        }

        [HttpPut("promotion")]
        public async Task<ActionResult> PromoteEmployee([FromBody] EmployeePromotionModel employeeUpdateModel)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(employeeUpdateModel);
            await _employeeService.PromoteEmloyee(employeeModel);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee([FromBody] EmployeeUpdateModel employeeUpdateModel)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(employeeUpdateModel);
            await _employeeService.DeleteEmployee(employeeModel);

            return NoContent();
        }
    }
}