using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Model
{
    public class SavingModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public double Amonut { get; set; }
        
        public DateTime Date { get; set; }
    }
}
