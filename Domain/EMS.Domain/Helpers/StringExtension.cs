namespace EMS.Domain.Helpers;

public static class StringExtension
{
    public static bool TryParseToIntArray(this string? str, out List<int> result)
    {
        result = new List<int>();
        
        foreach (var i in str ?? "")
        {
            if (!char.IsDigit(i))
                return false;
            result.Add(int.Parse(i.ToString()));
        }

        return true;
    }
}