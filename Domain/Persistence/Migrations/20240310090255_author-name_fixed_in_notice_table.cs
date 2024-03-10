using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class authorname_fixed_in_notice_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notice_provider_user_account_AuthorName",
                table: "notice");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "notice",
                newName: "author_name");

            migrationBuilder.RenameIndex(
                name: "IX_notice_AuthorName",
                table: "notice",
                newName: "IX_notice_author_name");

            migrationBuilder.AddForeignKey(
                name: "FK_notice_provider_user_account_author_name",
                table: "notice",
                column: "author_name",
                principalTable: "provider_user_account",
                principalColumn: "user_name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notice_provider_user_account_author_name",
                table: "notice");

            migrationBuilder.RenameColumn(
                name: "author_name",
                table: "notice",
                newName: "AuthorName");

            migrationBuilder.RenameIndex(
                name: "IX_notice_author_name",
                table: "notice",
                newName: "IX_notice_AuthorName");

            migrationBuilder.AddForeignKey(
                name: "FK_notice_provider_user_account_AuthorName",
                table: "notice",
                column: "AuthorName",
                principalTable: "provider_user_account",
                principalColumn: "user_name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
