﻿using API_Test.Data;
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
            if (people == null)
            {
                return NotFound(new { message = "Inga personer finns i databasen" });
            }
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
                    Interests = p.PeopleInterests
                    .Select(i => new InterestDto
                    {
                        Name = i.Interest.Name,
                        Description = i.Interest.Description
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
                    Links = p.PeopleInterests
                        .SelectMany(i => i.Links)
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

        [HttpPost("{personId}/interests")]
        public async Task<ActionResult> AddInterestToPerson(int personId, int? interestId, [FromBody] AddInterestDto addInterestDto)
        {
            var person = await _context.People.FindAsync(personId);

            if (person == null)
            {
                return NotFound(new { message = "Person eller intresse hittades inte." });
            }
            Interest interest;
            if (interestId.HasValue)
            {
                interest = await _context.Interests.FindAsync(interestId);
                if (interest == null)
                {
                    return NotFound(new { message = "Intresse hittades inte." });
                }
            }
            else
            {
                if (addInterestDto == null || string.IsNullOrWhiteSpace(addInterestDto.Name) || string.IsNullOrWhiteSpace(addInterestDto.Description))
                {
                    return BadRequest(new { message = "Ogilig intressedata." });
                }

                interest = await _context.Interests.FirstOrDefaultAsync(i => i.Name == addInterestDto.Name);

                if (interest == null)
                {
                    interest = new Interest
                    {
                        Name = addInterestDto.Name,
                        Description = addInterestDto.Description
                    };

                    _context.Interests.Add(interest);
                    await _context.SaveChangesAsync();
                }
            }

            var existingPeopleInterest = await _context.PeopleInterests
                .FirstOrDefaultAsync(pi => pi.PeopleId == personId && pi.InterestId == interest.Id);
            if (existingPeopleInterest != null)
            {
                return BadRequest(new { message = "Personen har redan detta intresse." });
            }

            var peopleInterest = new PeopleInterest
            {
                PeopleId = personId,
                InterestId = interest.Id
            };

            _context.PeopleInterests.Add(peopleInterest);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Intresset har lagts till personen." });
        }

        [HttpPost("{personId}/interestId/{interestId}/link", Name = "AddLinkToInterest")]
        public async Task<ActionResult> AddLinkToInterest(int personId, int interestId, [FromQuery] string link)
        {
            var peopleInterest = await _context.PeopleInterests
                .Include(pi => pi.People)
                .Include(pi => pi.Interest)
                .FirstOrDefaultAsync(pi => pi.PeopleId == personId && pi.InterestId == interestId);

            // Check if the person and interest exist
            if (peopleInterest == null)
            {
                return NotFound(new { message = "Person eller intresse hittades inte." });
            }
            // Check if the link is valid
            if (!Uri.TryCreate(link, UriKind.Absolute, out Uri? validatedUrl))
            {
                return BadRequest(new { message = "Ogiltig URL." });
            }

            var newLink = new Link
            {
                LinkName = validatedUrl.ToString(),
                PeopleInterestId = peopleInterest.Id
            };

            _context.Links.Add(newLink);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Länken har lagts till för intresset och personen." });
        }
    }
}
