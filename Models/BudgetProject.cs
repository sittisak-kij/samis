using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace samis.Models
{
    public class BudgetProject
    {
        public string budgetName { get; set; }
        public string proposed { get; set; }
        public string approved { get; set; }
        public int budgetTypeId { get; set; }
    }
}
