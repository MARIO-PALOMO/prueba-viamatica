using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace consultorio_seguros_api.Migrations
{
    public partial class CreacionBaseInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asegurado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    Edad = table.Column<string>(type: "varchar(2)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(10)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asegurado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    SumaAsegurada = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Prima = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeguroAsegurado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AseguradoId = table.Column<long>(type: "bigint", nullable: false),
                    SeguroId = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguroAsegurado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguroAsegurado_Asegurado_AseguradoId",
                        column: x => x.AseguradoId,
                        principalTable: "Asegurado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeguroAsegurado_Seguro_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeguroAsegurado_AseguradoId",
                table: "SeguroAsegurado",
                column: "AseguradoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeguroAsegurado_SeguroId",
                table: "SeguroAsegurado",
                column: "SeguroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeguroAsegurado");

            migrationBuilder.DropTable(
                name: "Asegurado");

            migrationBuilder.DropTable(
                name: "Seguro");
        }
    }
}
