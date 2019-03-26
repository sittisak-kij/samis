using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class StatusType
    {
        [Key]
        public int statusTypeId {get; set;}
        public string statusTypeName {get; set;}
    }
}