namespace IASI_IntelligentIndustrialSolutions.Models
{
    public class Consumo
    {
        public int IdConsumo { get; set; }
        public DateTime Data { get; set; }
        public int EquipamentoId { get; set; }
        public double Valor { get; set; }
        public double Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public string Descricao { get; set; }

        public Equipamento Equipamento { get; set; }
    }
}
