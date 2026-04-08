using Microsoft.AspNetCore.Mvc;
using PkAssessmentAPI.Application.Interfaces;
using PkAssessmentAPI.Models.DTOs.Employee;

namespace PkAssessmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            _logger.LogInformation("Fetching all employees");
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetByDepartment(int departmentId)
        {
            var employees = await _employeeService.GetEmployeesByDepartmentIdAsync(departmentId);
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddEmployeeDto employeeDto)
        {
            await _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(new { message = "Employee created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EditEmployeeDto employeeDto)
        {
            if (id != employeeDto.Id) return BadRequest("ID mismatch");

            var existing = await _employeeService.GetEmployeeByIdAsync(id);
            if (existing == null) return NotFound();

            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return Ok(new { message = "Employee updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _employeeService.GetEmployeeByIdAsync(id);
            if (existing == null) return NotFound();

            await _employeeService.DeleteEmployeeAsync(id);
            return Ok(new { message = "Employee deleted successfully" });
        }
    }
}
