using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSynergy.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixingNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Abilitis_Ability_AbilityId",
                table: "User_Abilitis");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Abilitis_Post_PostId",
                table: "User_Abilitis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis");

            migrationBuilder.RenameTable(
                name: "User_Abilitis",
                newName: "Post_Abilities");

            migrationBuilder.RenameIndex(
                name: "IX_User_Abilitis_PostId",
                table: "Post_Abilities",
                newName: "IX_Post_Abilities_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Abilitis_AbilityId",
                table: "Post_Abilities",
                newName: "IX_Post_Abilities_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_Abilities",
                table: "Post_Abilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Abilities_Ability_AbilityId",
                table: "Post_Abilities",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Abilities_Post_PostId",
                table: "Post_Abilities",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Abilities_Ability_AbilityId",
                table: "Post_Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Abilities_Post_PostId",
                table: "Post_Abilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_Abilities",
                table: "Post_Abilities");

            migrationBuilder.RenameTable(
                name: "Post_Abilities",
                newName: "User_Abilitis");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Abilities_PostId",
                table: "User_Abilitis",
                newName: "IX_User_Abilitis_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Abilities_AbilityId",
                table: "User_Abilitis",
                newName: "IX_User_Abilitis_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Abilitis",
                table: "User_Abilitis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Abilitis_Ability_AbilityId",
                table: "User_Abilitis",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Abilitis_Post_PostId",
                table: "User_Abilitis",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
