using System.Collections.Generic;

namespace Capstone.Models 
{
  public class Genre
  {
    public Genre()
    {
      this.JoinGenreShow = new HashSet<GenreShow>();
    }

    public int GenreId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<GenreShow> JoinGenreShow { get; set; }
  }
}