namespace EMS.Shared.Exceptions;

public class IncorrectPeselFormatException : BadRequestException
{
    public IncorrectPeselFormatException() : base("Incorrect pesel format.")
    {
    }
}
