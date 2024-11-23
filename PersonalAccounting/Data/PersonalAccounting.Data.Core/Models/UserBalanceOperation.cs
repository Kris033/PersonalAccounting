namespace PersonalAccounting.Data.Core.Models;

public class UserBalanceOperation
{
    public Guid Id { get; set; }

    public long BalanceUserId { get; set; }

    public UserBalance UserBalance { get; set; }

    public decimal ChangeAmount { get; set; }

    public DateTime DateChange { get; set; }

    public string ReasonChange { get; set; }
}
