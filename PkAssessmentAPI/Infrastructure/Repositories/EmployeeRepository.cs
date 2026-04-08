using PkAssessmentAPI.Domain.Entities;
using PkAssessmentAPI.Domain.Interfaces;

namespace PkAssessmentAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration, "Employee")
        {
        }

        public override async Task<int> AddAsync(Employee employee)
        {
            var query = @"INSERT INTO Employee (FirstName, LastName, EmailAddress, DateOfBirth, Salary, DepartmentId, PhoneNumber, CreatedDate, ModifiedDate) 
                          VALUES (@FirstName, @LastName, @EmailAddress, @DateOfBirth, @Salary, @DepartmentId, @PhoneNumber, GETUTCDATE(), GETUTCDATE())";

            return await ExecuteAsync(query, new
            {
                employee.FirstName,
                employee.LastName,
                employee.EmailAddress,
                employee.DateOfBirth,
                employee.Salary,
                employee.DepartmentId,
                employee.PhoneNumber
            });
        }

        public override async Task<int> UpdateAsync(Employee employee)
        {
            var query = @"UPDATE Employee 
                          SET FirstName = @FirstName, 
                              LastName = @LastName, 
                              EmailAddress = @EmailAddress, 
                              DateOfBirth = @DateOfBirth, 
                              Salary = @Salary, 
                              DepartmentId = @DepartmentId, 
                              PhoneNumber = @PhoneNumber, 
                              ModifiedDate = GETUTCDATE() 
                          WHERE Id = @Id";

            return await ExecuteAsync(query, new
            {
                employee.FirstName,
                employee.LastName,
                employee.EmailAddress,
                employee.DateOfBirth,
                employee.Salary,
                employee.DepartmentId,
                employee.PhoneNumber,
                employee.Id
            });
        }

        public async Task<IEnumerable<Employee>> GetByDepartmentIdAsync(int departmentId)
        {
            var query = "SELECT * FROM Employee WHERE DepartmentId = @DepartmentId";
            return await GetAllAsync(query, new { DepartmentId = departmentId });
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            var query = "SELECT * FROM Employee WHERE EmailAddress = @EmailAddress";
            return await GetFirstOrDefaultAsync(query, new { EmailAddress = email });
        }
    }
}
