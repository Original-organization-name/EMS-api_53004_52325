namespace EMS.Contracts.Dictionaries;

public class DictionaryItemDto
{
    public string Value { get; init; }

    public DictionaryItemDto(string value)
    {
        Value = value;
    }
}