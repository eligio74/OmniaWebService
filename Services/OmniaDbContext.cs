using Microsoft.EntityFrameworkCore;
using OmniaWebService.Models;

namespace OmniaWebService.Services
{
   public class OmniaDbContext : DbContext
   {
      private readonly IConfiguration configuration;
      public OmniaDbContext(IConfiguration configuration)
      {
         this.configuration=configuration;
      }

      public virtual DbSet<SaldiCC> SaldiCC => Set<SaldiCC>();
      public virtual DbSet<Spese> Spese => Set<Spese>();
      public virtual DbSet<DettaglioSpese> DettaglioSpese => Set<DettaglioSpese>();

      protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
         options.UseSqlite(configuration.GetConnectionString("Default"));
      }

      protected override void OnModelCreating (ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<SaldiCC>()
            .HasKey(a=> new {a.Id});

         modelBuilder.Entity<Spese>()
            .HasKey(a=> new {a.Id});

         modelBuilder.Entity<DettaglioSpese>()
            .HasKey(a=> new {a.Id});

         //In questo ambito vengono anche create le relazioni tra le tabelle
      }
   }
}