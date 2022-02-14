using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibrary.DAL.Migrations
{
    public partial class AddIdPropToTagEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tags_TagsName",
                table: "BookTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTag",
                table: "BookTag");

            migrationBuilder.DropIndex(
                name: "IX_BookTag_TagsName",
                table: "BookTag");

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 1, "книга 2021" });

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 1, "наука" });

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 2, "музыка" });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "книга 2021");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "музыка");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "наука");

            migrationBuilder.DropColumn(
                name: "TagsName",
                table: "BookTag");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "BookTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTag",
                table: "BookTag",
                columns: new[] { "BooksId", "TagsId" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "книга 2021" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "музыка" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "наука" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsId" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagsId",
                table: "BookTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tags_TagsId",
                table: "BookTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tags_TagsId",
                table: "BookTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Name",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTag",
                table: "BookTag");

            migrationBuilder.DropIndex(
                name: "IX_BookTag_TagsId",
                table: "BookTag");

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BookTag",
                keyColumns: new[] { "BooksId", "TagsId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "BookTag");

            migrationBuilder.AddColumn<string>(
                name: "TagsName",
                table: "BookTag",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTag",
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 1, "книга 2021" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 1, "наука" });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "BooksId", "TagsName" },
                values: new object[] { 2, "музыка" });

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagsName",
                table: "BookTag",
                column: "TagsName");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tags_TagsName",
                table: "BookTag",
                column: "TagsName",
                principalTable: "Tags",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
