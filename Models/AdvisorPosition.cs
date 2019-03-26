using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class AdvisorPosition
    {
        [Key]
        public int advisorPositionId {get; set;}
        public string advisorPositionName {get; set;}
    }
}