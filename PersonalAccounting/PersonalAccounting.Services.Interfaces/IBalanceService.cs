using PersonalAccounting.Services.Interfaces.Dtos.Balances;

namespace PersonalAccounting.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса баланса пользователя
/// </summary>
public interface IBalanceService
{
    /// <summary>
    /// Получение баланса текущего пользователя
    /// </summary>
    /// <param name="telegramId"></param>
    /// <returns></returns>
    Task<GetBalanceResponse> GetBalance(long telegramId);
}