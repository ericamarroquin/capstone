using System.Collections.Generic;

namespace Capstone.Models
{
  public class Actor 
  {
    public int ActorId { get; set; }
    public string Name { get; set; }

    public ICollection<ActingCredit> ActingCredits { get; set; }
  }
}