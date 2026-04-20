using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatAllocation.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SessionTypes_SessionID",
                table: "SessionTypes",
                column: "SessionID");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTypes_Sessions_SessionID",
                table: "SessionTypes",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTypes_Sessions_SessionID",
                table: "SessionTypes");

            migrationBuilder.DropIndex(
                name: "IX_SessionTypes_SessionID",
                table: "SessionTypes");
        }
    }
}
