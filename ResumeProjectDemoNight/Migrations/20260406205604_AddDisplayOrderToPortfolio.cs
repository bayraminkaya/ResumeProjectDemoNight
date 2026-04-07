using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeProjectDemoNight.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayOrderToPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Portfolios");
        }
    }
}
