using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Project
    {
        public ActivityInformation activityInformation { get; set; }
        public List<Budget> budgets { get; set; }
    }
}