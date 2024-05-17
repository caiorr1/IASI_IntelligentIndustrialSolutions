using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IASI_IntelligentIndustrialSolutions.Migrations
{
    /// <inheritdoc />
    public partial class oracledb_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_IASI_CONSUMO",
                columns: table => new
                {
                    id_consumo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data_consumo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    quantidade_consumo = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    tipo_energia_consumo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    emissao_gas_consumo = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IASI_CONSUMO", x => x.id_consumo);
                });

            migrationBuilder.CreateTable(
                name: "TB_IASI_EMPRESA",
                columns: table => new
                {
                    id_empresa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_empresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    setor_industrial_empresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    localizacao_empresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo_empresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    conformidade_regulamentar = table.Column<string>(type: "NVARCHAR2(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IASI_EMPRESA", x => x.id_empresa);
                });

            migrationBuilder.CreateTable(
                name: "TB_IASI_EQUIPAMENTO",
                columns: table => new
                {
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    localizacao_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_instalacao_equipamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    estado_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IASI_EQUIPAMENTO", x => x.id_equipamento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_IASI_CONSUMO");

            migrationBuilder.DropTable(
                name: "TB_IASI_EMPRESA");

            migrationBuilder.DropTable(
                name: "TB_IASI_EQUIPAMENTO");
        }
    }
}
