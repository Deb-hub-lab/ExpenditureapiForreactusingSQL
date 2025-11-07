using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyExpenditure.Migrations
{
    /// <inheritdoc />
    public partial class AddRemarksToExpenditure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Expenditures");
        }
    }
}
