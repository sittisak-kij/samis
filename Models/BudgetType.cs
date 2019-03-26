using System.ComponentModel.DataAnnotations;

namespace samis.Models
{
    public class BudgetType
    {
        [Key]
        public int budgetTypeId {get; set;}
        public string budgetTypeName {get; set;}
    }
}