using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class ActivityUnit
    {
        [Key]
        public int activityUnitId { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public int advisorId { get; set; }
        public Advisor advisor { get; set; }
    }
}