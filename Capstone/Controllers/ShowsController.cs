using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

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
    public async Task<ActionResult<Show>> Post(Show show)
    {
      _db.Shows.Add(show);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = show.ShowId }, show);
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
  }
}