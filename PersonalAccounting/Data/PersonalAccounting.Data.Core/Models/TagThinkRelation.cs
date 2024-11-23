namespace PersonalAccounting.Data.Core.Models;

public class TagThinkRelation
{
    public Guid ThinkId { get; set; }

    public ThinkAccountPlanned Think { get; set; }

    public long TagId { get; set; }

    public Tag Tag { get; set; }
}
