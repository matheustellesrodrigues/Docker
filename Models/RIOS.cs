namespace GS.Models
{
    public class RIOS
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public decimal Ph { get; set; }
        public decimal Turbidez { get; set; }
        public decimal OxigenioDissolvido { get; set; }
        public decimal Nitratos { get; set; }
        public decimal Fosfatos { get; set; }
        public int ColiformesTotais { get; set; }
        public DateTime DataMedicao { get; set; }
    }
}