using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_management_backoffice.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailID = table.Column<int>(type: "int", nullable: false),
                    PreviousFlag = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousStatus = table.Column<int>(type: "int", nullable: false),
                    UpdatedFlag = table.Column<int>(type: "int", nullable: false),
                    UpdatedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChangeHistory_Mails_MailID",
                        column: x => x.MailID,
                        principalTable: "Mails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistory_MailID",
                table: "ChangeHistory",
                column: "MailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistory");
        }
    }
}
