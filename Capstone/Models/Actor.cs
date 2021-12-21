using System.Collections.Generic;

namespace Capstone.Models
{
  public class Actor 
  {
    public Actor() 
    {
      this.JoinActingCredit = new HashSet<ActingCredit>(); 
    }

    public int ActorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ActingCredit> JoinActingCredit { get; set; }
  }
}