using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusJobOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "IsAcepted",
                table: "Job_Offers");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Job_Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Contract_Options_ContractOptionId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Job_Offers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAcepted",
                table: "Job_Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
