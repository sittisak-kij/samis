using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class BudgetDescription
    {
        [Key]
        public int budgetDescriptionId { get; set; }
        public string name { get; set; }

        public int budgetTypeId { get; set; }
        public BudgetType budgetType { get; set; }
    }
}