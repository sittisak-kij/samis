using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class BudgetDetail
    {
        [Key]
        public int budgetDetailId {get; set;}
        public string budgetDetailDescription {get; set;}
    }
}