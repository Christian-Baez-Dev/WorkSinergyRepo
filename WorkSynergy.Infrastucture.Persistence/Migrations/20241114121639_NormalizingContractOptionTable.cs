using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NormalizingContractOptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Abilities",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "ContractOption",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User_Abilitis",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User_Abilitis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User_Abilitis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User_Abilitis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User_Abilitis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "User_Abilities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User_Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User_Abilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User_Abilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User_Abilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User_Abilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Post_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Post_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Post_Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Post_Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Post_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ContractOptionId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Job_Rating",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Job_Rating",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Job_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Job_Rating",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Job_Rating",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Job_Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Job_Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Job_Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Job_Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Job_Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Abilities",
                table: "User_Abilities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contract_Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract_Options", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Abilitis_PostId",
                table: "User_Abilitis",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ContractOptionId",
                table: "Post",
                column: "ContractOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Contract_Options_ContractOptionId",
                table: "Post",
                column: "ContractOptionId",
                principalTable: "Contract_Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Contract_Options_ContractOptionId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Contract_Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis");

            migrationBuilder.DropIndex(
                name: "IX_User_Abilitis_PostId",
                table: "User_Abilitis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Abilities",
                table: "User_Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Post_ContractOptionId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User_Abilitis");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User_Abilitis");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User_Abilitis");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User_Abilitis");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User_Abilitis");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User_Abilities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "ContractOptionId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Job_Applications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "User_Abilities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContractOption",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis",
                columns: new[] { "PostId", "AbilityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Abilities",
                table: "User_Abilities",
                columns: new[] { "UserId", "AbilityId" });
        }
    }
}
