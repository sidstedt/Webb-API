namespace API_Test.Models
{
    public class PeopleInterest
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int InterestId { get; set; }

        public People People { get; set; } = null!;
        public Interest Interest { get; set; } = null!;
        public ICollection<Link> Links { get; set; } = new List<Link>();

    }
}
