using System.ComponentModel.DataAnnotations;

namespace API_Test.Models.DTOs
{
    public class InterestDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
    }
}
