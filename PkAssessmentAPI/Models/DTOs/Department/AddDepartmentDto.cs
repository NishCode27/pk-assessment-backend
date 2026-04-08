using System.ComponentModel.DataAnnotations;

namespace PkAssessmentAPI.Models.DTOs.Department
{
    public class AddDepartmentDto
    {
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
