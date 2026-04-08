using PkAssessmentAPI.Domain.Entities;
using PkAssessmentAPI.Models.DTOs.Department;

namespace PkAssessmentAPI.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto?> GetDepartmentByIdAsync(int id);
        Task<int> CreateDepartmentAsync(AddDepartmentDto departmentDto);
        Task<int> UpdateDepartmentAsync(EditDepartmentDto departmentDto);
        Task<int> DeleteDepartmentAsync(int id);
        Task<Department?> GetDepartmentByCodeAsync(string code);
    }
}
