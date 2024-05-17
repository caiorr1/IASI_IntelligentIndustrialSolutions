using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("TB_IASI_EQUIPAMENTO")]
    public class Equipamento
    {
        [Key]
        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Column("nome_equipamento")]
        [Required]
        public required string Nome { get; set; }

        [Column("tipo_equipamento")]
        [Required]
        public string Tipo { get; set; }

        [Column("localizacao_equipamento")]
        [Required]
        public string Localizacao { get; set; }

        [Column("data_instalacao_equipamento")]
        public DateTime DataInstalacao { get; set; }

        [Column("estado_equipamento")]
        [Required]
        public string Estado { get; set; }

        // Relacionamento com Consumo
        public ICollection<Consumo> Consumos { get; set; }
    }
}
