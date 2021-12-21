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

  public class GenreShowsController : ControllerBase
  {
    private readonly CapstoneContext _db;

    public GenreShowsController(CapstoneContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreShow>>> Get()
    {
      return await _db.GenreShow.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<GenreShow>> Post(GenreShow showgenre)
    {
      _db.GenreShow.Add(showgenre);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetGenreShow), new { id = showgenre.GenreShowId }, showgenre);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreShow>> GetGenreShow(int id)
    {
      var showgenre = await _db.GenreShow.FindAsync(id);
      if (showgenre == null)
      {
        return NotFound();
      }
      return showgenre;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, GenreShow showgenre)
    {
      if (id != showgenre.GenreShowId)
      {
        return BadRequest();
      }

      _db.Entry(showgenre).State = EntityState.Modified;

      try 
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GenreShowExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenreShow(int id)
    {
      var showgenre = await _db.GenreShow.FindAsync(id);
      if (showgenre == null)
      {
        return NotFound();
      }

      _db.GenreShow.Remove(showgenre);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool GenreShowExists(int id)
    {
      return _db.GenreShow.Any(e => e.GenreShowId == id);
    }
  }
}