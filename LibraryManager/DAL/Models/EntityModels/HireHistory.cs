using System;
using System.Collections.Generic;

namespace DAL.Models.EntityModels
{
    public class HireHistory
    {
        public int HireId { get; set; }
        public virtual ICollection<StoragePlaces> StoragePlaceId { get; set; }
        public virtual ICollection<Mediums> MediumId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
