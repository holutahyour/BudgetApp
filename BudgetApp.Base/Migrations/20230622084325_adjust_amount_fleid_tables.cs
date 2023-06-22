using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Base.Migrations
{
    public partial class adjust_amount_fleid_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amonut",
                table: "Savings",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Amonut",
                table: "Incomes",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Amonut",
                table: "Expenses",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Savings",
                newName: "Amonut");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Incomes",
                newName: "Amonut");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "Amonut");
        }
    }
}
