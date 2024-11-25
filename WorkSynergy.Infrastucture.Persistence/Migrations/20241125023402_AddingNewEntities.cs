using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Offers_Post_PostId",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ContractOption",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Job_Offers");

            migrationBuilder.RenameColumn(
                name: "FreelancerUserId",
                table: "Job_Offers",
                newName: "FreelancerId");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractOptionId",
                table: "Job_Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Job_Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Job_Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAcepted",
                table: "Job_Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iso3Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TotalPayment = table.Column<long>(type: "bigint", nullable: false),
                    CurrentPayment = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractOptionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreelancerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Contract_Options_ContractOptionId",
                        column: x => x.ContractOptionId,
                        principalTable: "Contract_Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fixed_Price_Milestones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixed_Price_Milestones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixed_Price_Milestones_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hourly_Milestone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    CurrentHours = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourly_Milestone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hourly_Milestone_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CurrencyId",
                table: "Post",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Offers_ContractOptionId",
                table: "Job_Offers",
                column: "ContractOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Offers_CurrencyId",
                table: "Job_Offers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractOptionId",
                table: "Contracts",
                column: "ContractOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CurrencyId",
                table: "Contracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixed_Price_Milestones_ContractId",
                table: "Fixed_Price_Milestones",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Hourly_Milestone_ContractId",
                table: "Hourly_Milestone",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Offers_Contract_Options_ContractOptionId",
                table: "Job_Offers",
                column: "ContractOptionId",
                principalTable: "Contract_Options",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Offers_Currencies_CurrencyId",
                table: "Job_Offers",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Offers_Post_PostId",
                table: "Job_Offers",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Currencies_CurrencyId",
                table: "Post",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Offers_Contract_Options_ContractOptionId",
                table: "Job_Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Offers_Currencies_CurrencyId",
                table: "Job_Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Offers_Post_PostId",
                table: "Job_Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Currencies_CurrencyId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Fixed_Price_Milestones");

            migrationBuilder.DropTable(
                name: "Hourly_Milestone");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Post_CurrencyId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Job_Offers_ContractOptionId",
                table: "Job_Offers");

            migrationBuilder.DropIndex(
                name: "IX_Job_Offers_CurrencyId",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ContractOptionId",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Job_Offers");

            migrationBuilder.DropColumn(
                name: "IsAcepted",
                table: "Job_Offers");

            migrationBuilder.RenameColumn(
                name: "FreelancerId",
                table: "Job_Offers",
                newName: "FreelancerUserId");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContractOption",
                table: "Job_Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Job_Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Offers_Post_PostId",
                table: "Job_Offers",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
