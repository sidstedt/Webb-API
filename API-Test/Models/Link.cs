using System.ComponentModel.DataAnnotations;

namespace API_Test.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string LinkName { get; set; } = string.Empty;
        public int PeopleInterestId { get; set; }

        // Navigation Properties
        public PeopleInterest PeopleInterest { get; set; } = null!;

        public Link() { }

        public Link(int id, string linkName)
        {
            Id = id;
            LinkName = linkName;
        }
    }
}
