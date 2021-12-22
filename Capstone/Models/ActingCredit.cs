namespace Capstone.Models
{
  public class ActingCredit
  {
    public int ActingCreditId { get; set; }
    public int ActorId { get; set; }
    public int ShowId { get; set; }
    public virtual Actor Actor { get; set; }
    public virtual Show Show { get; set; }
  }

  // public class AddActingCreditDto
  // {
  //   public int ActorId { get; set; }
  //   public int ShowId { get; set; }
  // }
}