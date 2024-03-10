using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Newtablenamednoticeadded4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "notice",
                newName: "updated");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "notice",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "notice",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "notice",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notice",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "notice",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "notice",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_notice_AuthorName",
                table: "notice",
                column: "AuthorName");

            migrationBuilder.CreateIndex(
                name: "IX_notice_id",
                table: "notice",
                column: "id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_notice_provider_user_account_AuthorName",
                table: "notice",
                column: "AuthorName",
                principalTable: "provider_user_account",
                principalColumn: "user_name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notice_provider_user_account_AuthorName",
                table: "notice");

            migrationBuilder.DropIndex(
                name: "IX_notice_AuthorName",
                table: "notice");

            migrationBuilder.DropIndex(
                name: "IX_notice_id",
                table: "notice");

            migrationBuilder.RenameColumn(
                name: "updated",
                table: "notice",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "notice",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "notice",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "notice",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "notice",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "notice",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "notice",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)");
        }
    }
}
