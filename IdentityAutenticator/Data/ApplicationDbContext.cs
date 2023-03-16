using GameBackEnd.Domain.Inventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Emit;

namespace IdentityAutenticator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Champion> Champions { get; set; }
        public override DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public override DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Configurations for Champion entity
            builder.Entity<Champion>().HasKey(c => c.Id);
            builder.Entity<Champion>().Property(c => c.Name).IsRequired();
            builder.Entity<Champion>().Property(c => c.Description).IsRequired();
            builder.Entity<Champion>().Property(c => c.Stats).IsRequired();
            builder.Entity<Champion>().Property(c => c.Level).IsRequired();
            builder.Entity<Champion>().Property(c => c.Attributes).IsRequired();
#pragma warning disable CS8603 // Possible null reference return.
            builder.Entity<Champion>()
      .Property(c => c.Attributes)
      .HasConversion(
          a => JsonConvert.SerializeObject(a),
          s => JsonConvert.DeserializeObject<ChampionAttributes>(s)
      );
#pragma warning restore CS8603 // Possible null reference return.

            // Seed data
            builder.Entity<Champion>().HasData(
                new Champion
                {
                    Id ="23",
                    Name = "Champion 1",
                    Description = "Description of Champion 1",
                    Stats = 1,
                    Level = 1,
                    Attributes = new ChampionAttributes
                    {
                        Ascension = "Ascension 1",
                        Claws = "Claws 1",
                        CoreEssence = "Core Essence 1",
                        Divinity = "Divinity 1",
                        Edition = "Edition 1",
                        Family = "Family 1",
                        Horns = "Horns 1",
                        Piercing = "Piercing 1",
                        Tail = "Tail 1",
                        Wings = "Wings 1"
                    },
                    UserId= "user1"
                },
                new Champion
                {
                    Id = "2",
                    Name = "Champion 2",
                    Description = "Description of Champion 2",
                    Stats = 3,
                    Level = 12,
                    Attributes = new ChampionAttributes
                    {
                        Ascension = "Ascension 2",
                        Claws = "Claws 2",
                        CoreEssence = "Core Essence 2",
                        Divinity = "Divinity 2",
                        Edition = "Edition 2",
                        Family = "Family 2",
                        Horns = "Horns 2",
                        Piercing = "Piercing 2",
                        Tail = "Tail 2",
                        Wings = "Wings 2"
                    },
                    UserId = "user1"
                }
            );
        }
    }
}