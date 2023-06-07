using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_management_backoffice.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdateUserID",
                table: "ChangeHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistory_UpdateUserID",
                table: "ChangeHistory",
                column: "UpdateUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeHistory_AspNetUsers_UpdateUserID",
                table: "ChangeHistory",
                column: "UpdateUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeHistory_AspNetUsers_UpdateUserID",
                table: "ChangeHistory");

            migrationBuilder.DropIndex(
                name: "IX_ChangeHistory_UpdateUserID",
                table: "ChangeHistory");

            migrationBuilder.DropColumn(
                name: "UpdateUserID",
                table: "ChangeHistory");
        }
    }
}
