namespace EMS.Domain.Exceptions;

public class IncorrectPeselFormatException : BadRequestException
{
    public IncorrectPeselFormatException() : base("Incorrect pesel format.")
    {
    }
}
