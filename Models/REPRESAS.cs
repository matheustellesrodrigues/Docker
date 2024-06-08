namespace GS.Models
{
    public class REPRESAS
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string LOCALIZACAO { get; set; }
        public decimal PH { get; set; }
        public decimal TURBIDEZ { get; set; }
        public decimal OXIGENIO_DISSOLVIDO { get; set; }
        public decimal NITRATOS { get; set; }
        public decimal FOSFATOS { get; set; }
        public int COLIFORMES_TOTAIS { get; set; }
        public DateTime DATA_MEDICAO { get; set; }
    }
}