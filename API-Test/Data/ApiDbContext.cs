using API_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Test.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PeopleInterest> PeopleInterests { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for People
            modelBuilder.Entity<People>().HasData(
                new People(1, "John", "Doe", "0731234567"),
                new People(2, "Jane", "Smith", "0732345678"),
                new People(3, "Alice", "Johnson", "0733456789"),
                new People(4, "Bob", "Brown", "0734567890")
            );

            // Seed data for Interest
            modelBuilder.Entity<Interest>().HasData(
                new Interest(1, "Programmering", "Allt om kodning"),
                new Interest(2, "Gaming", "Allt om spel"),
                new Interest(3, "Matlagning", "Allt om matlagning")
            );

            // Many-to-many relationships for People and Interest
            modelBuilder.Entity<PeopleInterest>()
                .HasData(
                    new PeopleInterest { Id = 1, PeopleId = 1, InterestId = 2 },
                    new PeopleInterest { Id = 2, PeopleId = 2, InterestId = 1 },
                    new PeopleInterest { Id = 3, PeopleId = 2, InterestId = 3 },
                    new PeopleInterest { Id = 4, PeopleId = 3, InterestId = 2 },
                    new PeopleInterest { Id = 5, PeopleId = 3, InterestId = 3 },
                    new PeopleInterest { Id = 6, PeopleId = 4, InterestId = 1 },
                    new PeopleInterest { Id = 7, PeopleId = 4, InterestId = 2 },
                    new PeopleInterest { Id = 8, PeopleId = 4, InterestId = 3 }
                );

            //// Seed data for Link
            modelBuilder.Entity<Link>()
                .HasData(
                    new Link { Id = 1, LinkName = "https://github.com", PeopleInterestId = 2 },
                    new Link { Id = 2, LinkName = "https://stackoverflow.com", PeopleInterestId = 2 },
                    new Link { Id = 3, LinkName = "https://www.gamereactor.com", PeopleInterestId = 1 },
                    new Link { Id = 4, LinkName = "https://www.fz.se", PeopleInterestId = 1 },
                    new Link { Id = 5, LinkName = "https://www.recept.se", PeopleInterestId = 3 },
                    new Link { Id = 6, LinkName = "https://www.koket.se", PeopleInterestId = 3 },
                    new Link { Id = 7, LinkName = "https://www.matklubben.se", PeopleInterestId = 3 }
                );
        }
    }
}