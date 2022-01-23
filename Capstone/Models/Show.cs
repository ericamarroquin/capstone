using System.Collections.Generic;

namespace Capstone.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinActingCredit = new HashSet<ActingCredit>();
    }
    public int ShowId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ActingCredit> JoinActingCredit { get; set; }
  }
}