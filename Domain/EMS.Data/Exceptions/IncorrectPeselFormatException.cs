namespace EMS.Data.Exceptions;

public class IncorrectPeselFormatException : BadRequestException
{
    public IncorrectPeselFormatException() : base("Incorrect pesel format.")
    {
    }
}
