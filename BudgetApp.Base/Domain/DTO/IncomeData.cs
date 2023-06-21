namespace BudgetApp.Base.Domain.DTO
{
    public class IncomeData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amonut { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; }
    }
}
