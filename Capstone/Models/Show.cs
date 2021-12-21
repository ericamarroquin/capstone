using System.Collections.Generic;

namespace Capstone.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinGenreShow = new HashSet<GenreShow>();
      this.JoinActingCredit = new HashSet<ActingCredit>();
    }
    public int ShowId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<GenreShow> JoinGenreShow { get; }
    public virtual ICollection<ActingCredit> JoinActingCredit { get; }
  }
}