namespace Domain.Entities.Post;

public class Post
{
    public long Id { get; set; }
    public int Likes { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string Link { get; set; } = null!;
    public string Text { get; set; } = null!;
}
