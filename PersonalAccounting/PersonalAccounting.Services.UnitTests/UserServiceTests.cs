using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;
using PersonalAccounting.Services.Interfaces;
using Xunit;

namespace PersonalAccounting.Services.UnitTests;

public class UserServiceTests
{
    private readonly IUserService _userService;
    private readonly DataContext _db;

    public UserServiceTests()
    {
        _db = new DataContext(
            new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);

        _userService = new UserService(_db);
    }

    [Fact]
    public async Task AccessAndUpsertUser_WhenNotExistInContext()
    {
        // Arrange
        var userIdTelegram = 1111;

        // Act
        await _userService.AccessAndUpsertUser(userIdTelegram);

        // Assert
        var user = await _db.User.FirstOrDefaultAsync(u => u.TelegramUserId == userIdTelegram);
        Assert.NotNull(user);
    }
}