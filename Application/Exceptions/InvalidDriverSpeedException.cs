namespace Application.Exceptions;

public class InvalidDriverSpeedException : ArgumentException
{
    public InvalidDriverSpeedException(string message) : base(message)
    {
    }
}
