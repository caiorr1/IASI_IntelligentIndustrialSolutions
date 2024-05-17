using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("TB_IASI_PREVISAO")]
    public class Previsao
    {
        [Key]
        [Column("id_previsao")]
        public int IdPrevisao { get; set; }

        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }

        [ForeignKey("IdEquipamento")]
        public Equipamento Equipamento { get; set; }

        [Column("data_previsao")]
        public DateTime Data { get; set; }

        [Column("tipo_previsao")]
        public string TipoPrevisao { get; set; }

        [Column("descricao_previsao")]
        public string Descricao { get; set; }

        [Column("probabilidade_previsao")]
        public float Probabilidade { get; set; }
    }
}
