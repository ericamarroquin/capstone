using System.Collections.Generic;

namespace Capstone.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinEntities = new HashSet<GenreShow>();
    }
    public int ShowId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<GenreShow> JoinEntities { get; }
  }
}