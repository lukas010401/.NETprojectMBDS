using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_management_backoffice.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "Mails");

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipient_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_MailID",
                table: "Recipient",
                column: "MailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
