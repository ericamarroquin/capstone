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
  public class ShowsController : ControllerBase
  {
    private readonly CapstoneContext _db;

    public ShowsController(CapstoneContext db)
    {
      _db = db; // allows us to use private database as public 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Show>>> Get()
    {
      return await _db.Shows.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Show>> Post(Show show, int actorId, int genreId)
    {
      _db.Shows.Add(show);
      await _db.SaveChangesAsync();

      if (actorId != 0)
      {
        _db.ActingCredit.Add(new ActingCredit() { ActorId = actorId, ShowId = show.ShowId });
      }
      if (genreId != 0)
      {
        _db.GenreShow.Add(new GenreShow() { GenreId = genreId, ShowId = show.ShowId });
      }

      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetShow), new { id = show.ShowId }, show);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Show>> GetShow(int id)
    {
      var show = await _db.Shows.FindAsync(id);
      if (show == null)
      {
        return NotFound();
      }
      return show;
    }

    [HttpPut("{id}")] // if needing partial updates, use PATCH
    public async Task<IActionResult> Put(int id, Show show)
    {
      if (id != show.ShowId)
      {
        return BadRequest();
      }

      _db.Entry(show).State = EntityState.Modified; // opens object for modification

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ShowExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent(); // returns passing code, no content meaning no additional info was added
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShow(int id)
    {
      var show = await _db.Shows.FindAsync(id);
      if (show == null)
      {
        return NotFound();
      }

      _db.Shows.Remove(show);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ShowExists(int id)
    {
      return _db.Shows.Any(e => e.ShowId == id);
    }
  }
}