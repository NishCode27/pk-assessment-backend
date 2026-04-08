using Microsoft.AspNetCore.Mvc;
using PkAssessmentAPI.Models.Entities;
using PkAssessmentAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PkAssessmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentRepository departmentRepository, ILogger<DepartmentController> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return Ok(new { message = "Department created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Department department)
        {
            if (id != department.Id) return BadRequest("ID mismatch");
            
            var existing = await _departmentRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _departmentRepository.UpdateAsync(department);
            return Ok(new { message = "Department updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _departmentRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _departmentRepository.DeleteAsync(id);
            return Ok(new { message = "Department deleted successfully" });
        }
    }
}
