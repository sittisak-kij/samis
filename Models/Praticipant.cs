using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Praticipant
    {
        [Key]
        public int participantId { get; set; }

        public int activityId { get; set; }
        public ActivityInformation activityInformation { get; set; }

        public int studentId { get; set; }
        public Student student { get; set; }

        public int phoneNumber { get; set; }
        public string email { get; set; }
    }
}