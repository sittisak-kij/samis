using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class ActivityType
    {
        [Key]
        public int activityTypeId {get; set;}

        public string actyivityTypeName {get; set;}
    }
}