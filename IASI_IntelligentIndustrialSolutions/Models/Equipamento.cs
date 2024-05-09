namespace IASI_IntelligentIndustrialSolutions.Models
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Localizacao { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }

        public ICollection<Consumo> Consumos { get; set; }
    }
