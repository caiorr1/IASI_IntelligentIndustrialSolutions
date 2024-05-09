namespace IASI_IntelligentIndustrialSolutions.Models
{
    public class Previsao
    {
        public int IdPrevisao { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public double VelocidadeVento { get; set; }
        public string DirecaoVento { get; set; }
        public double PressaoAtmosferica { get; set; }
        public string CondicaoMeteorologica { get; set; }
    }
}
