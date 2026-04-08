using System.Collections.Generic;
using System.Threading.Tasks;

namespace PkAssessmentAPI.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string query, object? parameters = null);
        Task<T?> GetFirstOrDefaultAsync(string query, object? parameters = null);
        Task<int> ExecuteAsync(string query, object? parameters = null);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
