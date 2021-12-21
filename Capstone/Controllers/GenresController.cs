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
  public class GenresController : ControllerBase
  {
    private readonly CapstoneContext _db;

    public GenresController(CapstoneContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> Get()
    {
      return await _db.Genres.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Genre>> Post(Genre genre)
    {
      _db.Genres.Add(genre);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetGenre), new { id = genre.GenreId }, genre);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenre(int id)
    {
      var genre = await _db.Genres.FindAsync(id);
      if (genre == null)
      {
        return NotFound();
      }
      return genre;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Genre genre)
    {
      if (id != genre.GenreId)
      {
        return BadRequest();
      }

      _db.Entry(genre).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GenreExists(id))
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
    public async Task<IActionResult> DeleteGenre(int id)
    {
      var genre = await _db.Genres.FindAsync(id);
      if (genre == null)
      {
        return NotFound();
      }

      _db.Genres.Remove(genre);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool GenreExists(int id)
    {
      return _db.Genres.Any(e => e.GenreId == id);
    }
  }
}