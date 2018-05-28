using DAL.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ModelsConfiguration
{
    public class StoragePlacesConfiguration
    {
        public void OnModelCreating(ModelBuilder storagePlacesConfiguration)
        {
            storagePlacesConfiguration.Entity<StoragePlaces>().HasKey(x => x.StoragePlaceId);
            storagePlacesConfiguration.Entity<StoragePlaces>().Property(x => x.StoragePlaceId).HasColumnType("int");

            storagePlacesConfiguration.Entity<StoragePlaces>().Property(x => x.StorageStatus).IsRequired();
            storagePlacesConfiguration.Entity<StoragePlaces>().Property(x => x.StorageStatus).HasColumnType("bit");

            storagePlacesConfiguration.Entity<StoragePlaces>().Property(x => x.StoragePlaceName).IsRequired();
            storagePlacesConfiguration.Entity<StoragePlaces>().Property(x => x.StoragePlaceName).HasColumnType("nvarchar(60)");
        }
    }
}
