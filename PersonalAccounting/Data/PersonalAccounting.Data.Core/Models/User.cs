using PersonalAccounting.Data.Enums;

namespace PersonalAccounting.Data.Core.Models;

public class User
{
    public long TelegramUserId { get; set; }

    public DateTime DateTimeRegister { get; set; }

    public EnumTypeAccount TypeAccount { get; set; }

    public List<ThinkAccountPlanned> ThinkAccountPlanneds { get; set; }

    public List<ThinkSample> ThinkSamples { get; set; }

    public List<Tag> TagsCreated { get; set; }

    public UserBalance UserBalance { get; set; }
}