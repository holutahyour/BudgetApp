using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Entities
{
    public abstract class AuditEntity
    {
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
