using API_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Test.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

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

            // Seed data for Link
            modelBuilder.Entity<Link>().HasData(
                new Link(1, "https://github.com"),
                new Link(2, "https://stackoverflow.com"),
                new Link(3, "https://www.gamereactor.com"),
                new Link(4, "https://www.fz.se"),
                new Link(5, "https://www.recept.se"),
                new Link(6, "https://www.koket.se"),
                new Link(7, "https://www.matklubben.se")
            );
            // Many-to-many relationships for People and Interest
            modelBuilder.Entity<People>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.People)
                .UsingEntity(j => j.HasData(
                    new { PeopleId = 1, InterestsId = 2 },
                    new { PeopleId = 2, InterestsId = 1 },
                    new { PeopleId = 2, InterestsId = 3 },
                    new { PeopleId = 3, InterestsId = 2 },
                    new { PeopleId = 3, InterestsId = 3 },
                    new { PeopleId = 4, InterestsId = 1 },
                    new { PeopleId = 4, InterestsId = 2 },
                    new { PeopleId = 4, InterestsId = 3 }
                    ));
            // Many-to-many relationships for Link and Interest
            modelBuilder.Entity<Link>()
                .HasMany(l => l.Interests)
                .WithMany(i => i.Links)
                .UsingEntity(j => j.HasData(
                    new { LinksId = 1, InterestsId = 1 },
                    new { LinksId = 2, InterestsId = 1 },
                    new { LinksId = 3, InterestsId = 2 },
                    new { LinksId = 4, InterestsId = 2 },
                    new { LinksId = 5, InterestsId = 3 },
                    new { LinksId = 6, InterestsId = 3 },
                    new { LinksId = 7, InterestsId = 3 }
                    ));

            // Many-to-many relationships for Link and People
            modelBuilder.Entity<Link>()
                .HasMany(l => l.People)
                .WithMany(i => i.Links)
                .UsingEntity(j => j.HasData(
                    new { LinksId = 1, PeopleId = 2 },
                    new { LinksId = 1, PeopleId = 4 },
                    new { LinksId = 2, PeopleId = 2 },
                    new { LinksId = 2, PeopleId = 4 },
                    new { LinksId = 3, PeopleId = 1 },
                    new { LinksId = 3, PeopleId = 3 },
                    new { LinksId = 3, PeopleId = 4 },
                    new { LinksId = 4, PeopleId = 1 },
                    new { LinksId = 4, PeopleId = 3 },
                    new { LinksId = 4, PeopleId = 4 },
                    new { LinksId = 5, PeopleId = 2 },
                    new { LinksId = 5, PeopleId = 3 },
                    new { LinksId = 5, PeopleId = 4 },
                    new { LinksId = 6, PeopleId = 2 },
                    new { LinksId = 6, PeopleId = 3 },
                    new { LinksId = 6, PeopleId = 4 },
                    new { LinksId = 7, PeopleId = 2 },
                    new { LinksId = 7, PeopleId = 3 },
                    new { LinksId = 7, PeopleId = 4 }

                ));
        }
    }
}