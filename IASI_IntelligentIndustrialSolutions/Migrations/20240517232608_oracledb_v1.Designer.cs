﻿// <auto-generated />
using System;
using IASI_IntelligentIndustrialSolutions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace IASI_IntelligentIndustrialSolutions.Migrations
{
    [DbContext(typeof(IasiContext))]
    [Migration("20240517232608_oracledb_v1")]
    partial class oracledb_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IASI_IntelligentIndustrialSolutions.Models.Consumo", b =>
                {
                    b.Property<int>("IdConsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_consumo");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsumo"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_consumo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double?>("EmissaoGas")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("emissao_gas_consumo");

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    b.Property<double>("Quantidade")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("quantidade_consumo");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_energia_consumo");

                    b.HasKey("IdConsumo");

                    b.ToTable("TB_IASI_CONSUMO");
                });

            modelBuilder.Entity("IASI_IntelligentIndustrialSolutions.Models.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_empresa");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"));

                    b.Property<string>("ConformidadeRegulamentar")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(1)")
                        .HasColumnName("conformidade_regulamentar");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("localizacao_empresa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_empresa");

                    b.Property<string>("SetorIndustrial")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("setor_industrial_empresa");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_empresa");

                    b.HasKey("IdEmpresa");

                    b.ToTable("TB_IASI_EMPRESA");
                });

            modelBuilder.Entity("IASI_IntelligentIndustrialSolutions.Models.Equipamento", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipamento"));

                    b.Property<DateTime>("DataInstalacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_instalacao_equipamento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("estado_equipamento");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("localizacao_equipamento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_equipamento");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_equipamento");

                    b.HasKey("IdEquipamento");

                    b.ToTable("TB_IASI_EQUIPAMENTO");
                });
#pragma warning restore 612, 618
        }
    }
}
