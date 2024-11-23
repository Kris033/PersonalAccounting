using PersonalAccounting.Data.Enums;

namespace PersonalAccounting.Data.Core.Models;

public class ThinkAccountPlanned
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string? Url { get; set; }

    public decimal Amount { get; set; }

    public EnumTypeOperation TypeOperation { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DatePlanned { get; set; }

    public DateTime? DateCompleted { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public List<TagThinkRelation> Tags { get; set; }
}
