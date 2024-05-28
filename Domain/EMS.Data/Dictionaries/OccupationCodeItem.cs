using EMS.Data.Abstractions;

namespace EMS.Data.Dictionaries;

public class OccupationCodeItem : IAggregateRoot
{
    public required string Code  { get; set; }
    public required string Value { get; set; }
}