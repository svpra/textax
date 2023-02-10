using Domain.Exceptions;

namespace Domain.Entities.Post;

public class Link
{
    public string Value { get; }
    
    public Link(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ValidationException($"Link {value} is invalid");
        Value = value;
    }
}
