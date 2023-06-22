using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Base.Migrations
{
    public partial class modify_budget_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amonut",
                table: "Budgets",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Budgets",
                newName: "Amonut");
        }
    }
}
