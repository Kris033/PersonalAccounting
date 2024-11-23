using PersonalAccounting.Data.Enums;

namespace PersonalAccounting.Data.Core.Models;

public class ThinkSample
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public decimal Amount { get; set; }

    public EnumTypeOperation TypeOperation { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public long AuthorId { get; set; }

    public User Author { get; set; }
}
