using System.Collections.Generic;

namespace DAL.Models.EntityModels
{
    public class StoragePlaces
    {
        public int StoragePlaceId { get; set; }
        public bool StorageStatus { get; set; }
        public string StoragePlaceName { get; set; }
        public virtual ICollection<Users> UserId { get; set; }
    }
}
