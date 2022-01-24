namespace Capstone.Models
{
  public class ActingCredit
  {
    public int ActingCreditId { get; set; }
    public int ActorId { get; set; }
    public Actor Actor { get; set; }
    public int ShowId { get; set; }
    public Show Show { get; set; }
  }
}