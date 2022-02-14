using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibrary.DAL.Migrations
{
    public partial class RemaneImageProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "Uri");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Url",
                table: "Images",
                newName: "IX_Images_Uri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uri",
                table: "Images",
                newName: "Url");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Uri",
                table: "Images",
                newName: "IX_Images_Url");
        }
    }
}
