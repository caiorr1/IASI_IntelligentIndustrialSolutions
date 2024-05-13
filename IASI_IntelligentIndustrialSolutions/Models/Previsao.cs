using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("tb_previsao")]
    public class Previsao
    {
        [Key]
        [Column("id_previsao")]
        public int IdPrevisao { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("temperatura")]
        public double Temperatura { get; set; }

        [Column("umidade")]
        public double Umidade { get; set; }

        [Column("velocidade_vento")]
        public double VelocidadeVento { get; set; }

        [Column("direcao_vento")]
        public string DirecaoVento { get; set; }

        [Column("pressao_atmosferica")]
        public double PressaoAtmosferica { get; set; }

        [Column("condicao_meteorologica")]
        public string CondicaoMeteorologica { get; set; }
    }
}
