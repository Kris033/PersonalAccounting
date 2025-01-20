using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;
using PersonalAccounting.Services.Interfaces;
using PersonalAccounting.Services.Interfaces.Dtos.Balances;

namespace PersonalAccounting.Services;

/// <summary>
/// Сервис баланса пользователя
/// </summary>
/// <param name="_db"></param>
public class BalanceService(DataContext _db) : IBalanceService
{
    /// <summary>
    /// Получение баланса текущего пользователя
    /// </summary>
    /// <param name="telegramId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetBalanceResponse> GetBalance(long telegramId)
        => await _db.UserBalance
            .Where(u => u.UserId == telegramId)
            .Select(u => new GetBalanceResponse
            {
                Balance = u.Balance,
                DateLastOperation = u.Operations.Select(d => d.DateChange).LastOrDefault()
            }).FirstOrDefaultAsync() ?? throw new Exception("Баланс пользователя не был найден");
}