using GameBackEnd.Application.Inventory.ApplicationServices;
using IdentityAutenticator.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<IChampionsService, ChampionsService>();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseInMemoryDatabase("MyDatabase"));
        builder.Services.AddInfrastructureIdentity(builder.Configuration);

        // Configure authorization policies
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser());
        });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Ingrese el token de autenticación en el siguiente formato: 'Bearer {token}'",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}