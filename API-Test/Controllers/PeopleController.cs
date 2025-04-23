using API_Test.Data;
using API_Test.Models;
using API_Test.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PeopleController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPeople")]
        public async Task<ActionResult<ICollection<PersonDto>>> GetPeoples()
        {
            var people = await _context.People
                .Select(p => new PersonDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone
                })
                .ToListAsync();
            return Ok(people);
        }

        [HttpGet(("{id}/interests"), Name = "GetPeopleInterestById")]

        public async Task<ActionResult<PersonInterestsDto>> GetPeopleInterestById(int id)
        {
            var people = await _context.People
                .Where(p => p.Id == id)
                .Select(p => new PersonInterestsDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    Interests = p.Interests
                    .Select(i => new InterestDto
                    {
                        Name = i.Name,
                        Description = i.Description
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
            if (people == null)
            {
                return NotFound(new { message = "Personen kunde inte hittas" });
            }
            return Ok(people);
        }

        [HttpGet("{id}/links", Name = "GetPeopleLinkById")]
        public async Task<ActionResult<PersonLinksDto>> GetPeopleLinkById(int id)
        {
            var people = await _context.People
                .Where(p => p.Id == id)
                .Select(p => new PersonLinksDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    Links = p.Links
                        .Select(l => new LinkDto
                        {
                            LinkName = l.LinkName
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
            if (people == null)
            {
                return NotFound(new { message = "personen kunde inte hittas" });
            }
            return Ok(people);
        }

        [HttpPost("{personId}/Interests/{interestId}")]
        public async Task<ActionResult> AddInterestToPerson(int personId, int interestId)
        {
            var person = await _context.People.FindAsync(personId);
            var interest = await _context.Interests.FindAsync(interestId);

            if (person == null || interest == null)
            {
                return NotFound(new { message = "Person eller intresse hittades inte." });
            }

            person.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Intresset har lagts till personen." });
        }

        [HttpPost("{personId}/InterestId/{interestId}", Name = "AddLinkToInterest")]
        public async Task<ActionResult> AddLinkToInterest(int personId, int interestId,[FromQuery] string link)
        {
            var person = await _context.People
                .Include(p => p.Interests)
                .FirstOrDefaultAsync(p => p.Id == personId);

            var interest = await _context.Interests
                .Include(i => i.People)
                .FirstOrDefaultAsync(i => i.Id == interestId);

            // Check if the person and interest exist
            if (person == null || interest == null)
            {
                return NotFound(new { message = "Person eller intresse hittades inte." });
            }
            // Check if the person has the interest
            if (!person.Interests.Any(i => i.Id == interest.Id))
            {
                return BadRequest(new { message = "Person och intresse matchar inte." });
            }
            // Check if the link is valid
            if (!Uri.TryCreate(link, UriKind.Absolute, out Uri? validatedUrl))
            {
                return BadRequest(new { message = "Ogiltig URL." });
            }

            var newLink = new Link
            {
                LinkName = validatedUrl.ToString()
            };
            // DONT FORGET TO ADD THE LINK TO THE INTEREST
            // interest.Links.Add(newLink);
            // DONT FORGET TO ADD THE LINK TO THE PERSON
            // person.Links.Add(newLink);
            // DONT FORGET TO ADD THE LINK TO THE DB
            // _context.Links.Add(newLink);
            // await _context.SaveChangesAsync();

            return Ok(new { message = "Länken har lagts till intresset." });
        }
    }
}
