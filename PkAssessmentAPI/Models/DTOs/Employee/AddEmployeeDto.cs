using System.ComponentModel.DataAnnotations;

namespace PkAssessmentAPI.Models.DTOs.Employee
{
    public class AddEmployeeDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
