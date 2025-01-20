namespace PersonalAccounting.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса пользователя
/// </summary>
public interface IUserService
{
    Task AccessAndUpsertUser(long telegramId);
}