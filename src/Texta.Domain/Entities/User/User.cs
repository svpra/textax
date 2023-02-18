namespace Domain.Entities.User;

public class User
{
    public string Nick { get; set; } = null!;
    public int Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;    
    public string GithubLink { get; set; }
}
