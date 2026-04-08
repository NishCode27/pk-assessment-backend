using PkAssessmentAPI.Domain.Entities;

namespace PkAssessmentAPI.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId);
        Task<Employee?> GetByEmailAsync(string email);
    }
}
