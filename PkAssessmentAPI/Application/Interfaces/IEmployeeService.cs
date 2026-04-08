using PkAssessmentAPI.Models.DTOs.Employee;

namespace PkAssessmentAPI.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(AddEmployeeDto employeeDto);
        Task<int> UpdateEmployeeAsync(EditEmployeeDto employeeDto);
        Task<int> DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentIdAsync(int departmentId);
    }
}
