using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    [Table("TB_IASI_EMPRESA")]
    public class Empresa
    {
        [Key]
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        [Column("nome_empresa")]
        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        public string Nome { get; set; }

        [Column("setor_industrial_empresa")]
        [Required(ErrorMessage = "O setor industrial da empresa é obrigatório.")]
        public string SetorIndustrial { get; set; }

        [Column("localizacao_empresa")]
        [Required(ErrorMessage = "A localização da empresa é obrigatória.")]
        public string Localizacao { get; set; }

        [Column("tipo_empresa")]
        [Required(ErrorMessage = "O tipo da empresa é obrigatório.")]
        public string Tipo { get; set; }

        [Column("conformidade_regulamentar")]
        public char ConformidadeRegulamentar { get; set; } = 'N'; // Valor padrão 'N'

    }
}
