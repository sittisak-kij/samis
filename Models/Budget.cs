using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Budget
    {
        [Key]
        public int budgetId { get; set; }

        public int activityId { get; set; }
        public ActivityInformation activityInformation { get; set; }

        public int budgetDescriptionId { get; set; }
        public BudgetDescription budgetDescription { get; set; }

        public int budgetStatusId { get; set; }
        public BudgetStatus budgetStatus { get; set; }

        public double amount { get; set; }
    }
}