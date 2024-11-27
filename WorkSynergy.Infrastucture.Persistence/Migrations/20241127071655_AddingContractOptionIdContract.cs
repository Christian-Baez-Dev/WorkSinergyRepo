using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingContractOptionIdContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "ContractOptionId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts",
                column: "ContractOptionId",
                principalTable: "Contract_Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "ContractOptionId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts",
                column: "ContractOptionId",
                principalTable: "Contract_Options",
                principalColumn: "Id");
        }
    }
}
