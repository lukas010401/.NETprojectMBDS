using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_management_backoffice.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Mails_MailID",
                table: "Recipient");

            migrationBuilder.DropIndex(
                name: "IX_Recipient_MailID",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "MailID",
                table: "Recipient");

            migrationBuilder.CreateTable(
                name: "MailRecipient",
                columns: table => new
                {
                    MailID = table.Column<int>(type: "int", nullable: false),
                    RecipientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRecipient", x => new { x.MailID, x.RecipientID });
                    table.ForeignKey(
                        name: "FK_MailRecipient_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailRecipient_Recipient_RecipientID",
                        column: x => x.RecipientID,
                        principalTable: "Recipient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailRecipient_RecipientID",
                table: "MailRecipient",
                column: "RecipientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailRecipient");

            migrationBuilder.AddColumn<int>(
                name: "MailID",
                table: "Recipient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_MailID",
                table: "Recipient",
                column: "MailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Mails_MailID",
                table: "Recipient",
                column: "MailID",
                principalTable: "Mails",
                principalColumn: "ID");
        }
    }
}
