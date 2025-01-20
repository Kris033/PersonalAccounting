using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;

namespace PersonalAccounting.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")),
            ServiceLifetime.Scoped);

        var app = builder.Build();

        app.Run();
    }
}
