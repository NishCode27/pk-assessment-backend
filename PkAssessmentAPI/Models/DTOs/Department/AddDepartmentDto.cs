using System.ComponentModel.DataAnnotations;

namespace PkAssessmentAPI.Models.DTOs.Department
{
    public class AddDepartmentDto
    {
        [Required]
        [MaxLength(50)]
        public required string Code { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        public required string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
