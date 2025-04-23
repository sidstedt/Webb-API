using System.ComponentModel.DataAnnotations;

namespace API_Test.Models.DTOs
{
    public class LinkDto
    {
        [Required]
        [MaxLength(200)]
        public string LinkName { get; set; } = string.Empty;
    }
}
