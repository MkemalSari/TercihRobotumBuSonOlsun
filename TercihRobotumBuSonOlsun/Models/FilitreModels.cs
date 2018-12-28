using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace TercihRobotumBuSonOlsun.Models
{
    public class FilitreModels
    {
        
        public bool Burslu { get; set; }
        public bool KKTC { get; set; }
        public bool Devlet { get; set; }
        public bool Vakif { get; set; }

       

        public bool Lisans { get; set; }
        public bool OnLisans { get; set; }
        public bool Tm { get; set; }
        public bool Tyt { get; set; }
        public bool Mf { get; set; }
        public bool Ts { get; set; }
        public bool Dil { get; set; }
        public string PuanMin { get; set; }
        public string PuanMax { get; set; }
        public bool Ingilizce { get; set; }
        public bool Turkce { get; set; }

        //public string ProgramKodu { get; set; }
        //public string ProgramAdi { get; set; }
        //public string PuanTuru { get; set; }
        //public string Kontenjan { get; set; }
        //public string Yerlesen { get; set; }
        //public string EnKucukPuan { get; set; }
        //public string EnBuyukPuan { get; set; }

        public string AramaMetni { get; set; }
        public int? Page { get; set; }

        public IPagedList<TercihVeriModel> TercihVerileri { get; set; }

    }
}