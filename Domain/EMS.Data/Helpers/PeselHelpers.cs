using EMS.Data.Employee.Enum;
using EMS.Data.Exceptions;

namespace EMS.Data.Helpers;

public static class PeselHelpers
{
    private static readonly int[] _weights = new int[10] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
   
    public static bool IsValid(string? value)
    {
        if(string.IsNullOrWhiteSpace(value)) return true;
        if(!value.TryParseToIntArray(out List<int> pesel)) return false;
        if (pesel.Count != 11) return false;

        var sum = _weights.Zip(pesel, (weight, p) => weight * p).Sum();
        
        var calculatedControlDigit = (10 - sum % 10) % 10;
        return calculatedControlDigit == pesel[10];
    }
    
    public static DateTime? GetBirthDate(string? pesel)
    {
        if (!IsValid(pesel)) throw new IncorrectPeselFormatException();

        if (string.IsNullOrWhiteSpace(pesel)) return null;
        var year = int.Parse(pesel.Substring(0, 2));
        var month = int.Parse(pesel.Substring(2, 2));
        var day = int.Parse(pesel.Substring(4, 2));
        
        if (month <= 12)
            year += 1900;
        else if (month <= 32)
        {
            year += 2000;
            month -= 20;
        }
        
        return new DateTime(year, month, day);
    }

    public static Gender? GetGenderFromPesel(string? pesel)
    {
        if (!IsValid(pesel)) throw new IncorrectPeselFormatException();

        if (string.IsNullOrWhiteSpace(pesel)) return null;
        var gender = int.Parse(pesel![9].ToString());
        return gender % 2 == 0 ? Gender.Female : Gender.Male;
    }
}
