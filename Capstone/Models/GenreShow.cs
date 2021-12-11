namespace Capstone.Models
{
  public class GenreShow
  {
    public int GenreShowId { get; set; }
    public int GenreId { get; set; }
    public int ShowId { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual Show Show { get; set; }
  }
}