using PkAssessmentAPI.Models.Entities;
using System.Threading.Tasks;

namespace PkAssessmentAPI.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetByCodeAsync(string code);
    }
}
