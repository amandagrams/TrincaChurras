using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurrasTrinca.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(300)", nullable: false),
                    ValorComBebida = table.Column<double>(nullable: false),
                    ValorSemBebida = table.Column<double>(nullable: false),
                    ValorArrecadado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChurrasId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorPago = table.Column<double>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    ComBebida = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Churras_ChurrasId",
                        column: x => x.ChurrasId,
                        principalTable: "Churras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_ChurrasId",
                table: "Participantes",
                column: "ChurrasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Churras");
        }
    }
}
