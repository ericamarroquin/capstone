using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using System.Linq;

namespace Capstone.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActingCreditsController : ControllerBase
  {
    private readonly CapstoneContext _db;

    public ActingCreditsController(CapstoneContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActingCredit>>> Get()
    {
      return await _db.ActingCredit.ToListAsync();
    }

    public async Task<ActionResult<Show>> AddActingCredit(ActingCredit newActingCredit)
    {
      Show show = await _db.Shows
        .Include(show => show.JoinActingCredit)
        .ThenInclude(join => join.Actor)
        .FirstOrDefaultAsync(show => show.ShowId == newActingCredit.ShowId);

      if (show == null)
      {
        return NotFound();
      }

      Actor actor = 

    }

    // [HttpPost]
    // public async Task<ActionResult<ActingCredit>> Post(ActingCredit actingcredit)
    // {
    //   _db.ActingCredit.Add(actingcredit);
    //   await _db.SaveChangesAsync();

    //   return CreatedAtAction(nameof(GetActingCredit), new { id = actingcredit.ActingCreditId }, actingcredit);
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<ActingCredit>> GetActingCredit(int id)
    // {
    //   var credit = await _db.ActingCredit.FindAsync(id);
    //   if (credit == null)
    //   {
    //     return NotFound();
    //   }
    //   return credit;
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, ActingCredit credit)
    // {
    //   if (id != credit.ActingCreditId)
    //   {
    //     return BadRequest();
    //   }

    //   _db.Entry(credit).State = EntityState.Modified;

    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!ActingCreditExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }
    //   return NoContent();
    // }
    
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteActingCredit(int id)
    // {
    //   var credit = await _db.ActingCredit.FindAsync(id);
    //   if (credit == null)
    //   {
    //     return NotFound();
    //   }

    //   _db.ActingCredit.Remove(credit);
    //   await _db.SaveChangesAsync();

    //   return NoContent();
    // }

    // private bool ActingCreditExists(int id)
    // {
    //   return _db.ActingCredit.Any(e => e.ActingCreditId == id);
    // }
  }
}