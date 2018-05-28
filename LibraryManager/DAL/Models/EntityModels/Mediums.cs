using Shared;
using System.Collections.Generic;

namespace DAL.Models.EntityModels
{
    public class Mediums
    {
        public int MediumId { get; set; }
        public MediumType MediumType { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public virtual ICollection<StoragePlaces> StoragePlaces { get; set; }
    }
}
