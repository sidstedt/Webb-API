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
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPeoples()
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

        [HttpGet(("{id}"), Name = "GetPeopleInterestById")]

        public async Task<ActionResult<PersonInterestsDto>> GetPeopleInterestById(int id)
        {
            var people = await _context.People
                .Where(p => p.Id == id)
                .Select(p => new PersonInterestsDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    Interests = p.Interests
                    .Select(i => new InterestDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound(new { message = "Personen kunde inte hittas" });
            }
            return Ok(people);
        }
    }
}
