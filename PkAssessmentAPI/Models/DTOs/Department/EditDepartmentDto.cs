using System.ComponentModel.DataAnnotations;

namespace PkAssessmentAPI.Models.DTOs.Department
{
    public class EditDepartmentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Code { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
