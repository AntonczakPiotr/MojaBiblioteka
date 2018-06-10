using DAL.Models.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Models.EntityModels
{
    public class ContexDb : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<StoragePlaces> StoragePlaces { get; set; }
        public DbSet<Mediums> Mediums { get; set; }
        public DbSet<HireHistory> HireHistory { get; set; }

        public ContexDb()
        {

        }

        public ContexDb(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var usersConfiguration = new UsersConfiguration();
            usersConfiguration.OnModelCreating(modelBuilder);

            var mediumsConfiguration = new MediumsConfiguration();
            mediumsConfiguration.OnModelCreating(modelBuilder);

            var storagePlacesConfiguration = new StoragePlacesConfiguration();
            storagePlacesConfiguration.OnModelCreating(modelBuilder);

            var hireHistoryConfiguration = new HireHistoryConfiguration();
            hireHistoryConfiguration.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
