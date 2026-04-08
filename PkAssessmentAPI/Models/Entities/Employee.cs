namespace PkAssessmentAPI.Models.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public long DepartmentId { get; set; }
    }
}
