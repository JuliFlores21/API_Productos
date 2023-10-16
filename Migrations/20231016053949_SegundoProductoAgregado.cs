using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Productos.Migrations
{
    /// <inheritdoc />
    public partial class SegundoProductoAgregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Cantidad", "Descripcion", "Nombre" },
                values: new object[] { 2, 22, "Descripcion producto 2", "Producto 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: 2);
        }
    }
}
