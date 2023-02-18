using Domain.Entities.User;

namespace Domain.Entities.User;

public class Id
{
    public int Value { get; }
    
    public Id(int value)
    {
        Value = value;
    }
}
