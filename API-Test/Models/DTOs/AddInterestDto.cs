using System.ComponentModel.DataAnnotations;

namespace API_Test.Models.DTOs
{
    public class AddInterestDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
    }
}
