
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Models
{
    public class BudgetModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }
        
        public DateTime Date { get; set; }

        [Required]
        public IncomeModel[] Incomes { get; set; }

        [Required]
        public ExpenseModel[] Expenses { get; set; }

        [Required]
        public SavingModel[] Savings { get; set; }
    }
}
