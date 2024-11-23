namespace PersonalAccounting.Data.Core.Models;

/// <summary>
/// Теле
/// </summary>
public class TelegramUserSession
{
    public Guid SessionId { get; set; }

    public long TelegramId { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }
}
