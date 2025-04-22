using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Test.Models.DTOs
{
    public class PersonLinksDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; }

        // Navigation properties
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
