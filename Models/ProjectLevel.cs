using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class ProjectLevel
    {
        [Key]
        public int projectLevelId { get; set; }
        public string name { get; set; }
    }
}