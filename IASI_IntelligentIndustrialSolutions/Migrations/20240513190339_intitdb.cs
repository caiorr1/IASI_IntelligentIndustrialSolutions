using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IASI_IntelligentIndustrialSolutions.Migrations
{
    /// <inheritdoc />
    public partial class intitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_equipamento",
                columns: table => new
                {
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    serie = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_aquisicao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_equipamento", x => x.id_equipamento);
                });

            migrationBuilder.CreateTable(
                name: "tb_previsao",
                columns: table => new
                {
                    id_previsao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    temperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    umidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    velocidade_vento = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    direcao_vento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    pressao_atmosferica = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    condicao_meteorologica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_previsao", x => x.id_previsao);
                });

            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    IdConsumo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EquipamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Valor = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Quantidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.IdConsumo);
                    table.ForeignKey(
                        name: "FK_Consumos_tb_equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "tb_equipamento",
                        principalColumn: "id_equipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_EquipamentoId",
                table: "Consumos",
                column: "EquipamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "tb_previsao");

            migrationBuilder.DropTable(
                name: "tb_equipamento");
        }
    }
}
