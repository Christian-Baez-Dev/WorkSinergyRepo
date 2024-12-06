using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalHoursJobOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "Job_Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Job_Offers");
        }
    }
}
