using System.Collections.Generic;

namespace Capstone.Models
{
  public class Show
  {

    public int ShowId { get; set; }
    public string Name { get; set; }

    public ICollection<ActingCredit> ActingCredits { get; set; }
  }
}