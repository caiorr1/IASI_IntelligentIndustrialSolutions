using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("TB_IASI_CONSUMO")]
    public class Consumo
    {
        [Key]
        [Column("id_consumo")]
        public int IdConsumo { get; set; }

        [Column("id_equipamento")]
        [ForeignKey("Equipamento")]
        public int EquipamentoId { get; set; }

        [Column("data_consumo")]
        [Required]
        public DateTime Data { get; set; }

        [Column("quantidade_consumo")]
        [Required]
        public double Quantidade { get; set; }

        [Column("tipo_energia_consumo")]
        [Required]
        public required string UnidadeMedida { get; set; }

        [Column("emissao_gas_consumo")]
        public double? EmissaoGas { get; set; }

        public required string Descricao { get; set; }

        public virtual required Equipamento Equipamento { get; set; }
    }
}
