using System.Collections.Generic;

namespace Capstone.Models
{
  public class Actor 
  {
    public Actor() 
    {
      this.JoinEntities = new HashSet<ActingCredit>(); 
    }

    public int ActorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ActingCredit> JoinEntities { get; set; }
  }
}