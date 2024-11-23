using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data;

namespace PersonalAccounting.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")),
            ServiceLifetime.Scoped);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();

        app.Run();
    }
}
