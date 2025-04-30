using System.ComponentModel.DataAnnotations;

namespace API_Test.Models
{
    public class Interest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<PeopleInterest> PeopleInterests { get; set; } = new List<PeopleInterest>();

        public Interest() { }

        public Interest(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
