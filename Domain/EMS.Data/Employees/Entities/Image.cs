using EMS.Data.Models;

namespace EMS.Data.Employees.Entities;

public class Image : Entity
{
    public byte[] Content { get; set; }
}