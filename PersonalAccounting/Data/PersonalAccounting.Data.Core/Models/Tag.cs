namespace PersonalAccounting.Data.Core.Models;

public class Tag
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public string Name { get; set; }

    public List<TagThinkRelation> Thinks { get; set; }
}
