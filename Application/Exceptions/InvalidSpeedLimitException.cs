namespace Application.Exceptions;

public class InvalidSpeedLimitException : ArgumentException
{
    public InvalidSpeedLimitException(string message) : base(message)
    {
    }
}
