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

    [HttpPost]
    public async Task<ActionResult<ActingCredit>> Post(ActingCredit actingcredit)
    {
      _db.ActingCredit.Add(actingcredit);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetActingCredit), new { id = actingcredit.ActingCreditId }, actingcredit);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActingCredit>> GetActingCredit(int id)
    {
      var credit = await _db.ActingCredit.FindAsync(id);
      if (credit == null)
      {
        return NotFound();
      }
      return credit;
    }
  }
}