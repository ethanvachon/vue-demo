namespace backend.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}