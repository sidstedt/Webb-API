using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Test.Models
{
    public class People
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
        public ICollection<PeopleInterest> PeopleInterests { get; set; } = new List<PeopleInterest>();

        public People() { }

        public People(int id, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
