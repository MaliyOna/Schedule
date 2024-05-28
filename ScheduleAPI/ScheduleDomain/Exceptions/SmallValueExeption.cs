namespace ScheduleDomain.Exceptions;
public class SmallValueExeption : Exception
{
    public SmallValueExeption()
    {
    }

    public SmallValueExeption(string message)
        : base(message)
    {
    }

    public SmallValueExeption(string message, Exception inner)
        : base(message, inner)
    {
    }
}
