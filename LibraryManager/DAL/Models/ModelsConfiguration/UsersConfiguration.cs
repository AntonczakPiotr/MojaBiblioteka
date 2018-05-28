using DAL.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.ModelsConfiguration
{
    public class UsersConfiguration
    {
        public void OnModelCreating(ModelBuilder usersConfiguration)
        {
            usersConfiguration.Entity<Users>().HasKey(x => x.UserId);
            usersConfiguration.Entity<Users>().Property(x => x.UserId).HasColumnType("int");

            usersConfiguration.Entity<Users>().Property(x => x.Name).IsRequired();
            usersConfiguration.Entity<Users>().Property(x => x.Name).HasColumnType("nvarchar(30)");

            usersConfiguration.Entity<Users>().Property(x => x.Surname).IsRequired();
            usersConfiguration.Entity<Users>().Property(x => x.Surname).HasColumnType("nvarchar(30)");

            usersConfiguration.Entity<Users>().Property(x => x.Login).HasColumnType("nvarchar(30)");

            usersConfiguration.Entity<Users>().Property(x => x.Password).HasColumnType("nvarchar(30)");

            usersConfiguration.Entity<Users>().Property(x => x.Phone).IsRequired();
            usersConfiguration.Entity<Users>().Property(x => x.Phone).HasColumnType("nvarchar(9)");

            usersConfiguration.Entity<Users>().Property(x => x.Adress).IsRequired();
            usersConfiguration.Entity<Users>().Property(x => x.Adress).HasColumnType("nvarchar(60)");

            usersConfiguration.Entity<Users>().Property(x => x.Email).IsRequired();
            usersConfiguration.Entity<Users>().Property(x => x.Email).HasColumnType("nvarchar(253)");
        }
    }
}
