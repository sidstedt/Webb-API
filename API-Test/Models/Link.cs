using System.ComponentModel.DataAnnotations;

namespace API_Test.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string LinkName { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<People> People { get; set; } = new List<People>();
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();

        public Link() { }

        public Link(int id, string linkName)
        {
            Id = id;
            LinkName = linkName;
        }
    }
}
