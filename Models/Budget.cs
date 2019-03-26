using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class Budget
    {
        [Key]
        public int budgetId {get; set;}
        
        public int activityId {get; set;}
        public ActivityInformation activityInformation {get; set;}

        public int budgetDetailId {get; set;}
        public BudgetDetail budgetDetail {get; set;}

        public double amount {get; set;}

        public int budgetTypeId {get; set;}
        public BudgetType budgetType {get; set;}
    }
}