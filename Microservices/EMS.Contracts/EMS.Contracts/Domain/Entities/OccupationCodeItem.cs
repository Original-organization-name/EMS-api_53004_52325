using EMS.Shared.Abstractions;

namespace EMS.Contracts.Domain.Entities;

public class OccupationCodeItem : IAggregateRoot
{
    public required string Code  { get; set; }
    public required string Value { get; set; }
}