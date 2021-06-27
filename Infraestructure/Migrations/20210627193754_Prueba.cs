using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electrodoméstico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrodoméstico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ElectrodomésticoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Electrodoméstico_ElectrodomésticoId",
                        column: x => x.ElectrodomésticoId,
                        principalTable: "Electrodoméstico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoCategoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ElectrodomésticoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCategoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_TipoCategoria_Electrodoméstico_ElectrodomésticoId",
                        column: x => x.ElectrodomésticoId,
                        principalTable: "Electrodoméstico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_ElectrodomésticoId",
                table: "Sucursal",
                column: "ElectrodomésticoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCategoria_ElectrodomésticoId",
                table: "TipoCategoria",
                column: "ElectrodomésticoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "TipoCategoria");

            migrationBuilder.DropTable(
                name: "Electrodoméstico");
        }
    }
}
