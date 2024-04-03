namespace EMS.Data.Models;

public abstract class EditableDictionaryItem : Entity
{
    public required string Value { get; set; } = "";
}