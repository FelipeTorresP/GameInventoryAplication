using IdentityAutenticator.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IdentityAutenticator
{
    public static class UserDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Agregar usuarios de prueba
            var userManager = context.GetService<UserManager<ApplicationUser>>();
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var user1 = new ApplicationUser
            {
                UserName = "user1",
                Email = "user1@example.com",
                EmailConfirmed = true
            };
            user1.PasswordHash = passwordHasher.HashPassword(user1, "password");
            await userManager.CreateAsync(user1);

            var user2 = new ApplicationUser
            {
                UserName = "user2",
                Email = "user2@example.com",
                EmailConfirmed = true
            };
            user2.PasswordHash = passwordHasher.HashPassword(user2, "password");
            await userManager.CreateAsync(user2);

            // Guardar cambios en la base de datos
            await context.SaveChangesAsync();
        }
    }
}