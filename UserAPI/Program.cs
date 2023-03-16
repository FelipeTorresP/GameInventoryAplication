using ApplicationServices.Interfaces;
using IdentityAutenticator;
using IdentityAutenticator.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseInMemoryDatabase("MyDatabase"));
        builder.Services.AddInfrastructureIdentity(builder.Configuration);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        // Get an instance of the ApplicationDbContext from the container
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            UserDbContextSeed.SeedAsync(dbContext).Wait();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}