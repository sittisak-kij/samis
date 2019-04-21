using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Advisor
    {
        [Key]
        public int advisorId {get; set;}
        public string name {get; set;}
        public string phoneNumber { get; set; }
        public string lineID { get; set; }
        public string email { get; set; }

        public int advisorPositionId {get; set;}
        public AdvisorPosition advisorPosition {get; set;}
    }
}