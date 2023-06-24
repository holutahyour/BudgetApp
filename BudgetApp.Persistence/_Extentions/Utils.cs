using BudgetApp.Base.Domain.Entities;
namespace BudgetApp.Persistence._Extentions
{
    public static class Utils
    {
        public static double TotalExpenses(Expense[] expenses)
        {
            double total = 0;

            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }

            return total;
        }
        public static double TotalIncomes(Income[] incomes)
        {
            double total = 0;

            foreach (var income in incomes)
            {
                total += income.Amount;
            }

            return total;
        }

        public static double TotalSavings(Saving[] savings)
        {
            double total = 0;

            foreach (var saving in savings)
            {
                total += saving.Amount;
            }

            return total;
        }
    }
}
