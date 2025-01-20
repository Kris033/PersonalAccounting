namespace PersonalAccounting.Services.Interfaces.Dtos.Balances;

/// <summary>
/// Модель ответа на запрос получение баланса текущего пользователя
/// </summary>
public class GetBalanceResponse
{
    /// <summary>
    /// Текущий баланс
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Дата и время последней операции
    /// </summary>
    public DateTime? DateLastOperation { get; set; }
}