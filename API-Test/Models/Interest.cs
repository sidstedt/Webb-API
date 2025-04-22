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
        public ICollection<People> People { get; set; } = new List<People>();
        public ICollection<Link> Links { get; set; } = new List<Link>();

        public Interest() { }

        public Interest(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
