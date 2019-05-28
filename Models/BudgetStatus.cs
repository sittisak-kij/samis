using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class BudgetStatus
    {
        [Key]
        public int budgetStatusId { get; set; }
        public string name { get; set; }
    }
}