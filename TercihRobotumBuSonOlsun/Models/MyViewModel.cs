using TercihRobotumBuSonOlsun.Models;

namespace TercihimNihaiProje.Models
{
    public class MyViewModel
    {
        public int Id { get; set; }
        public string ProgramKodu { get; set; }
        public string ProgramAdi { get; set; }
        public string PuanTuru { get; set; }
        public string Kontenjan { get; set; }
        public string Yerlesen { get; set; }
        public string EnKucukPuan { get; set; }
        public string EnBuyukPuan { get; set; }


        public int TercihListemModelId { get; set; }
        public TercihListemModel TercihListemModel { get; set; }
    }
}