using System;
using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class ActivityInformation
    {
        [Key]
        public int activityId { get; set; }

        public int activityUnitId { get; set; }
        public ActivityUnit activityUnit { get; set; }

        public string referenceNumber { get; set; }
        public string activityName { get; set; }

        public int typeId { get; set; }
        public ActivityType activityType { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public string venue { get; set; }
        public int semester { get; set; }
        public int year { get; set; }
        public int participant { get; set; }

        public int statusTypeId { get; set; }
        public StatusType statusType { get; set; }

        public int advisorId { get; set; }
        public Advisor advisor { get; set; }
    }
}