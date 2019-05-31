using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class LocationType
    {
        [Key]
        public int locationTypeId { get; set; }
        public string locationTypeName { get; set; }
    }
}