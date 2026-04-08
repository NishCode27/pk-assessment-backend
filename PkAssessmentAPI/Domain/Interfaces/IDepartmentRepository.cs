using PkAssessmentAPI.Domain.Entities;

namespace PkAssessmentAPI.Domain.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetByCodeAsync(string code);
    }
}
