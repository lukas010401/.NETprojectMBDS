using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_management_backoffice.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Mails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mails_CreateUserId",
                table: "Mails",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_AspNetUsers_CreateUserId",
                table: "Mails",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_AspNetUsers_CreateUserId",
                table: "Mails");

            migrationBuilder.DropIndex(
                name: "IX_Mails_CreateUserId",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Mails");
        }
    }
}
