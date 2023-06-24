
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Entities
{
    public class Budget : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Income> Incomes { get; set; }
        public virtual List<Saving> Savings { get; set; }
    }
}
