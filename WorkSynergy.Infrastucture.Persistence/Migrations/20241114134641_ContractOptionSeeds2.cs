using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContractOptionSeeds2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contract_Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "FixedPrice");

            migrationBuilder.UpdateData(
                table: "Contract_Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "PerHour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contract_Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "e");

            migrationBuilder.UpdateData(
                table: "Contract_Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "e");
        }
    }
}
