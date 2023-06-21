using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Entities
{
    public class Saving : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public double Amonut { get; set; }
        
        public DateTime Date { get; set; }

        [Required]
        public int BudgetId { get; set; }
    }
}
