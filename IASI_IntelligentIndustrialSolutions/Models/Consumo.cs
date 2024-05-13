using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int IdConsumo { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("Equipamento")]
        public int EquipamentoId { get; set; }

        [Required]
        public double Valor { get; set; }

        [Required]
        public double Quantidade { get; set; }

        [Required]
        public string UnidadeMedida { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        // Navigation property
        public Equipamento Equipamento { get; set; }
    }
}
