using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;
using PersonalAccounting.Data.Core.Models;
using PersonalAccounting.Services.Interfaces;

namespace PersonalAccounting.Services;

public class UserService(DataContext _db) : IUserService
{
    public async Task AccessAndUpsertUser(long telegramId)
    {
        var user = await _db.User.FirstOrDefaultAsync(u => u.TelegramUserId == telegramId);
        if (user == null)
        {
            user = new User
            {
                TelegramUserId = telegramId,
                DateTimeRegister = DateTime.UtcNow,
                UserBalance = new UserBalance
                {
                    UserId = telegramId
                }
            };
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}