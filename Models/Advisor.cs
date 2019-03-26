using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Advisor
    {
        [Key]
        public int advisorId {get; set;}
        public string name {get; set;}
        
        public int advisorPositionId {get; set;}
        public AdvisorPosition advisorPosition {get; set;}
    }
}