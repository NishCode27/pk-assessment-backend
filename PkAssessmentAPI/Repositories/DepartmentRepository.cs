using Microsoft.Extensions.Configuration;
using PkAssessmentAPI.Models.Entities;
using System.Threading.Tasks;

namespace PkAssessmentAPI.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration, "Department")
        {
        }

        public override async Task<int> AddAsync(Department entity)
        {
            var query = @"INSERT INTO Department (DepartmentCode, DepartmentName, Description, CreatedDate, ModifiedDate) 
                          VALUES (@DepartmentCode, @DepartmentName, @Description, GETUTCDATE(), GETUTCDATE())";
            
            return await ExecuteAsync(query, new
            {
                entity.DepartmentCode,
                entity.DepartmentName,
                entity.Description
            });
        }

        public override async Task<int> UpdateAsync(Department entity)
        {
            var query = @"UPDATE Department 
                          SET DepartmentCode = @DepartmentCode, 
                              DepartmentName = @DepartmentName, 
                              Description = @Description, 
                              ModifiedDate = GETUTCDATE() 
                          WHERE Id = @Id";

            return await ExecuteAsync(query, new
            {
                entity.DepartmentCode,
                entity.DepartmentName,
                entity.Description,
                entity.Id
            });
        }

        public async Task<Department?> GetByCodeAsync(string code)
        {
            var query = "SELECT * FROM Department WHERE DepartmentCode = @Code";
            return await GetFirstOrDefaultAsync(query, new { Code = code });
        }
    }
}
