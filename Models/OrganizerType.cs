using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class OrganizerType
    {
        [Key]
        public int organizerTypeId {get; set;}
        public string organizerTypeName {get; set;}
    }
}