using PkAssessmentAPI.Domain.Entities;
using PkAssessmentAPI.Domain.Interfaces;

namespace PkAssessmentAPI.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration, "Department")
        {
        }

        public override async Task<int> AddAsync(Department department)
        {
            var query = @"INSERT INTO Department (Code, Name, Description, CreatedDate, ModifiedDate) 
                          VALUES (@Code, @Name, @Description, GETUTCDATE(), GETUTCDATE())";

            return await ExecuteAsync(query, new
            {
                department.Code,
                department.Name,
                department.Description
            });
        }

        public override async Task<int> UpdateAsync(Department department)
        {
            var query = @"UPDATE Department 
                          SET Code = @Code, 
                              Name = @Name, 
                              Description = @Description, 
                              ModifiedDate = GETUTCDATE() 
                          WHERE Id = @Id";

            return await ExecuteAsync(query, new
            {
                department.Code,
                department.Name,
                department.Description,
                department.Id
            });
        }

        public async Task<Department?> GetByCodeAsync(string code)
        {
            var query = "SELECT * FROM Department WHERE Code = @Code";
            return await GetFirstOrDefaultAsync(query, new { Code = code });
        }
    }
}
