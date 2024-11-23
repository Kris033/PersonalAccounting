namespace PersonalAccounting.Data.Core.Models;

public class UserBalance
{
    public long UserId { get; set; }

    public User User { get; set; }

    public decimal Balance { get; set; }

    public List<UserBalanceOperation> Operations { get; set; }
}
