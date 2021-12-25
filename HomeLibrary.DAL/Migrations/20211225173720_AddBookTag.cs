using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibrary.DAL.Migrations
{
    public partial class AddBookTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    TagsName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => new { x.BooksId, x.TagsName });
                    table.ForeignKey(
                        name: "FK_BookTag_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTag_Tags_TagsName",
                        column: x => x.TagsName,
                        principalTable: "Tags",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "Name",
                value: "книга 2021");

            migrationBuilder.InsertData(
                table: "Tags",
                column: "Name",
                value: "музыка");

            migrationBuilder.InsertData(
                table: "Tags",
                column: "Name",
                value: "наука");

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 1, "книга 2021" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 2, "музыка" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 1, "наука" });

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagsName",
                table: "BookTag",
                column: "TagsName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
