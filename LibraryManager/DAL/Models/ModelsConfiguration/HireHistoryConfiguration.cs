using DAL.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.ModelsConfiguration
{
    public class HireHistoryConfiguration
    {
        public void OnModelCreating(ModelBuilder hireHistoryConfiguration)
        {
            hireHistoryConfiguration.Entity<HireHistory>().HasKey(x => x.HireId);
            hireHistoryConfiguration.Entity<HireHistory>().Property(x => x.HireId).HasColumnType("int");

            hireHistoryConfiguration.Entity<HireHistory>().Property(x => x.StartDate).IsRequired();
            hireHistoryConfiguration.Entity<HireHistory>().Property(x => x.StartDate).HasColumnType("datetime2");

            hireHistoryConfiguration.Entity<HireHistory>().Property(x => x.FinishDate).IsRequired();
            hireHistoryConfiguration.Entity<HireHistory>().Property(x => x.FinishDate).HasColumnType("datetime2");
        }
    }
}
