namespace EMS.Data.Exceptions;

public class PeselExistException : BadRequestException
{
    public PeselExistException(string pesel) : base($"The pesel '{pesel}' already exist.")
    {
    }
}
