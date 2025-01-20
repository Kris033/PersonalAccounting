using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;
using PersonalAccounting.Data.Core.Models;
using PersonalAccounting.Data.Enums;
using PersonalAccounting.Services.Interfaces;
using Xunit;

namespace PersonalAccounting.Services.UnitTests;

public class BalanceServiceTests
{
    private readonly DataContext _db;
    private readonly IBalanceService _balanceService;

    public BalanceServiceTests() 
    {
        _db = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);

        _balanceService = new BalanceService(_db);
    }

    [Fact]
    public async Task GetBalance_WhenIfExistTelegramUser()
    {
        // Arrange
        var user = new User
        {
            TelegramUserId = 1111,
            DateTimeRegister = DateTime.UtcNow,
            TypeAccount = EnumTypeAccount.Activate,
            UserBalance = new UserBalance
            {
                Balance = 20,
                Operations =
                [
                    new UserBalanceOperation
                    {
                        ChangeAmount = 20,
                        DateChange = DateTime.UtcNow,
                        ReasonChange = ""
                    }
                ]
            }
        };
        await _db.AddAsync(user);
        await _db.SaveChangesAsync();

        // Act
        var response = await _balanceService.GetBalance(user.TelegramUserId);

        // Assert
        Assert.Equal(response.Balance, user.UserBalance.Balance);
        Assert.NotNull(response.DateLastOperation);
        Assert.Equal(response.DateLastOperation, user.UserBalance.Operations[0].DateChange);
    }
}