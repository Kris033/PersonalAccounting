using PersonalAccounting.Data.Enums;

namespace PersonalAccounting.Data.Core.Models;

public class User
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public DateTime DateTimeRegister { get; set; }

    public EnumTypeAccount TypeAccount { get; set; }

    public string? Token { get; set; }

    public DateTime? DateTimeTokenExpired { get; set; }

    public List<ThinkAccountPlanned> ThinkAccountPlanneds { get; set; }

    public List<ThinkSample> ThinkSamples { get; set; }

    public List<TelegramUserSession> TelegramUserSessions { get; set; }

    public List<Tag> TagsCreated { get; set; }

    public UserBalance UserBalance { get; set; }
}
