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
        [Required(ErrorMessage = "O campo Nome do Equipamento é obrigatório.")]
        public string Nome { get; set; }

        [Column("tipo_equipamento")]
        [Required(ErrorMessage = "O campo Tipo de Equipamento é obrigatório.")]
        public string Tipo { get; set; }

        [Column("localizacao_equipamento")]
        [Required(ErrorMessage = "O campo Localização do Equipamento é obrigatório.")]
        public string Localizacao { get; set; }

        [Column("data_instalacao_equipamento")]
        public DateTime DataInstalacao { get; set; }

        [Column("estado_equipamento")]
        [Required(ErrorMessage = "O campo Estado do Equipamento é obrigatório.")]
        public string Estado { get; set; }

    }
}
