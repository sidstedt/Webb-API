using System.ComponentModel.DataAnnotations;

namespace API_Test.Models.DTOs
{
    public class LinkDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string LinkName { get; set; } = string.Empty;
    }
}
