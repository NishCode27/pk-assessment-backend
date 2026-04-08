using Microsoft.AspNetCore.Mvc;
using PkAssessmentAPI.Application.Interfaces;
using PkAssessmentAPI.Models.DTOs.Department;

namespace PkAssessmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            _logger.LogInformation("Fetching all departments");
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AddDepartmentDto departmentDto)
        {
            await _departmentService.CreateDepartmentAsync(departmentDto);
            return Ok(new { message = "Department created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EditDepartmentDto editDepartmentDto)
        {
            if (id != editDepartmentDto.Id) return BadRequest("ID mismatch");

            var existing = await _departmentService.GetDepartmentByIdAsync(id);
            if (existing == null) return NotFound();

            await _departmentService.UpdateDepartmentAsync(editDepartmentDto);
            return Ok(new { message = "Department updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _departmentService.GetDepartmentByIdAsync(id);
            if (existing == null) return NotFound();

            await _departmentService.DeleteDepartmentAsync(id);
            return Ok(new { message = "Department deleted successfully" });
        }
    }
}
