using DAL.Models.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.EntityModels
{
    public class ContexDb : DbContext
    {
        public DbSet<Users> Users { get; set; }

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
    }
}
