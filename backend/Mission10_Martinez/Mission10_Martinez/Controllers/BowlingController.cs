using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Martinez.Models;

namespace Mission10_Martinez.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _context;

        public BowlingController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        [HttpGet(Name = "GetBowlingLeague")]
        public IActionResult GetBowlers()
        {
            var bowlers = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    firstName = b.BowlerFirstName,
                    middle = b.BowlerMiddleInit,
                    lastName = b.BowlerLastName,
                    teamName = b.Team.TeamName,
                    address = b.BowlerAddress,
                    city = b.BowlerCity,
                    state = b.BowlerState,
                    zip = b.BowlerZip,
                    phone = b.BowlerPhoneNumber
                })
                .ToList();

            return Ok(bowlers);
        }
    }
}