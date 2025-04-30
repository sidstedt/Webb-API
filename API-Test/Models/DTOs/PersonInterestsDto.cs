using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Test.Models.DTOs
{
    public class PersonInterestsDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; }

        // Navigation properties
        public ICollection<InterestDto> Interests { get; set; } = new List<InterestDto>();
    }
}
