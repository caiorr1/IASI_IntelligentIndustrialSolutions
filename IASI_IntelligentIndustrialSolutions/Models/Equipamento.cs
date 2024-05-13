using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("tb_equipamento")]
    public class Equipamento
    {
        [Key]
        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("marca")]
        public string Marca { get; set; }

        [Required]
        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("serie")]
        public string Serie { get; set; }

        [Required]
        [Column("data_aquisicao")]
        public DateTime DataAquisicao { get; set; }

        [Required]
        [Column("localizacao")]
        public string Localizacao { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }

        // Relacionamento com Consumo
        public ICollection<Consumo> Consumos { get; set; }
    }
}
