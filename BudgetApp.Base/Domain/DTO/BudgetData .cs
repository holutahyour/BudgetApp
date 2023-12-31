﻿namespace BudgetApp.Base.Domain.DTO
{
    public class BudgetData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }
        public double TotalSavings { get; set; }
        public IncomeData[] Incomes { get; set; }
        public ExpenseData[] Expenses { get; set; }
        public SavingData[] Savings { get; set; }
    }
}
