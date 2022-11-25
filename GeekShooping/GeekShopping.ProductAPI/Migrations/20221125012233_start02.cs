using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class start02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "character varying(30000)",
                maxLength: 30000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2, "T-Shirt", "Descricao Teste", "", "Name", 69.9m },
                    { 3, "T-Shirt", "Descricao Teste 02", "", "Name 3", 6.4m },
                    { 4, "T-Shirt", "Descricao Teste 4", "", "Name 3", 41.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "image_url",
                table: "product",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30000)",
                oldMaxLength: 30000);
        }
    }
}
