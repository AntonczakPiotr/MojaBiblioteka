using DAL.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ModelsConfiguration
{
    public class MediumsConfiguration
    {
        public void OnModelCreating(ModelBuilder mediumsConfiguration)
        {
            mediumsConfiguration.Entity<Mediums>().HasKey(x => x.MediumId);
            mediumsConfiguration.Entity<Mediums>().Property(x => x.MediumId).HasColumnType("int");

            mediumsConfiguration.Entity<Mediums>().Property(x => x.MediumType).HasColumnType("int");

            mediumsConfiguration.Entity<Mediums>().Property(x => x.Title).IsRequired();
            mediumsConfiguration.Entity<Mediums>().Property(x => x.Title).HasColumnType("nvarchar(60)");

            mediumsConfiguration.Entity<Mediums>().Property(x => x.Year).IsRequired();
            mediumsConfiguration.Entity<Mediums>().Property(x => x.Year).HasColumnType("int");

            mediumsConfiguration.Entity<Mediums>().Property(x => x.Author).IsRequired();
            mediumsConfiguration.Entity<Mediums>().Property(x => x.Author).HasColumnType("nvarchar(60)");

            mediumsConfiguration.Entity<Mediums>().Property(x => x.Cover).IsRequired();
            mediumsConfiguration.Entity<Mediums>().Property(x => x.Cover).HasColumnType("nvarchar(60)");
        }
    }
}
