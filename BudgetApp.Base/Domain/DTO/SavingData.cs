﻿namespace BudgetApp.Base.Domain.DTO
{
    public class SavingData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; }
    }
}
