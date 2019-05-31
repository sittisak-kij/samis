using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Origanizer
    {
        [Key]
        public int organizerId { get; set; }

        public int activityId { get; set; }
        public ActivityInformation ActivityInformation { get; set; }

        public int studentId { get; set; }
        public Student student { get; set; }

        public int organierTypeId { get; set; }
        public OrganizerType organizerType { get; set; }

        public int phoneNumber { get; set; }
        public string email { get; set; }
    }
}