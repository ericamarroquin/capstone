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
  public class ActorsController : ControllerBase
  {
    private readonly CapstoneContext _db;

    public ActorsController(CapstoneContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> Get()
    { 
      return await _db.Actors.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Actor>> Post(Actor actor)
    {
      _db.Actors.Add(actor);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetActor), new { id = actor.ActorId }, actor);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
      var actor = await _db.Actors.FindAsync(id);
      if (actor == null)
      {
        return NotFound();
      }
      return actor;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Actor actor) 
    // IActionResult allows us to return a custom response, including errors
    // ActionResult allows for predefined returns, like returning a View or resource
    {
      if (id != actor.ActorId)
      {
        return BadRequest();
      }

      _db.Entry(actor).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ActorExists(id))
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
    public async Task<IActionResult> DeleteActor(int id)
    {
      var actor = await _db.Actors.FindAsync(id);
      if (actor == null)
      {
        return NotFound();
      }

      _db.Actors.Remove(actor);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // PUT /actors/<actor-id>/shows/<show-id>
    // add show to actor
    // PUT is idempotent - actor can only be added to a show once
    [HttpPost("{actorId}/shows/{showId}")]
    public async Task<IActionResult> AddActingCredit(int showId, int actorId)
    {
      if (showId == 0 || actorId == 0)
      {
        return BadRequest();
      }

      _db.ActingCredits.Add(new ActingCredit() { ShowId = showId, ActorId = actorId });
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // GET /<actor-id>/shows
    // get shows credited to specific actor

    [HttpGet("{actorId}/shows")]
    public async Task<ActionResult<IEnumerable<ActingCredit>>> GetActorShows(int actorId)
    { 
      // i want:
      // a list of all shows
      // in which their id is in ActingCredit
      // that match with the actor id
      // match those show id

      // return await _db.ActingCredit.ToListAsync();

      return await _db.ActingCredits
        .Where(actor => actor.ActorId == actorId)
        .ToListAsync();   
    }

    private bool ActorExists(int id)
    {
      return _db.Actors.Any(e => e.ActorId == id);
    }
  }
}