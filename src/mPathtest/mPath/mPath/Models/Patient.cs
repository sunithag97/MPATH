namespace mPath.Models
{
  public class Patient
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public List<Recommendation> Recommendations { get; set; }
  }
}
