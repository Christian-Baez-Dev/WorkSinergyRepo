using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewEntitiesAndFixingApplicationContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tags_Tag_PostId",
                table: "Post_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_Tags",
                table: "Post_Tags");

            migrationBuilder.DropIndex(
                name: "IX_Post_Tags_PostId",
                table: "Post_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_Rating",
                table: "Job_Rating");

            migrationBuilder.DropIndex(
                name: "IX_Job_Rating_PostId",
                table: "Job_Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_Applications",
                table: "Job_Applications");

            migrationBuilder.DropIndex(
                name: "IX_Job_Applications_PostId",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Post_Tags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Job_Rating");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Job_Applications");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Post",
                newName: "ContractOption");

            migrationBuilder.AddColumn<double>(
                name: "From",
                table: "Post",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "To",
                table: "Post",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Job_Rating",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Job_Applications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_Tags",
                table: "Post_Tags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_Rating",
                table: "Job_Rating",
                columns: new[] { "PostId", "ApplicantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_Applications",
                table: "Job_Applications",
                columns: new[] { "PostId", "ApplicantId" });

            migrationBuilder.CreateTable(
                name: "Ability",
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
                    table.PrimaryKey("PK_Ability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Abilities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Abilities", x => new { x.UserId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_User_Abilities_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Abilitis",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Abilitis", x => new { x.PostId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_User_Abilitis_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Abilitis_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Tags_TagId",
                table: "Post_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Abilities_AbilityId",
                table: "User_Abilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Abilitis_AbilityId",
                table: "User_Abilitis",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Tags_Tag_TagId",
                table: "Post_Tags",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tags_Tag_TagId",
                table: "Post_Tags");

            migrationBuilder.DropTable(
                name: "User_Abilities");

            migrationBuilder.DropTable(
                name: "User_Abilitis");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_Tags",
                table: "Post_Tags");

            migrationBuilder.DropIndex(
                name: "IX_Post_Tags_TagId",
                table: "Post_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_Rating",
                table: "Job_Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_Applications",
                table: "Job_Applications");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "ContractOption",
                table: "Post",
                newName: "PaymentMethod");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Post_Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Job_Rating",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Job_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Job_Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Job_Applications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "PK_Post_Tags",
                table: "Post_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_Rating",
                table: "Job_Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_Applications",
                table: "Job_Applications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Tags_PostId",
                table: "Post_Tags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Rating_PostId",
                table: "Job_Rating",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Applications_PostId",
                table: "Job_Applications",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Tags_Tag_PostId",
                table: "Post_Tags",
                column: "PostId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
