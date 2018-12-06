using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TercihimNihaiProje.Models;

namespace TercihRobotumBuSonOlsun.Models
{
    public class TercihInitializer: DropCreateDatabaseIfModelChanges<TercihContext>
    {
        protected override void Seed(TercihContext context)
        {
           
            List<MyViewModel> tercihler = new List<MyViewModel>()
            {
                new MyViewModel(){ProgramKodu="11111111",ProgramAdi="sdü bilgisayar",PuanTuru="mf",Kontenjan="15",Yerlesen="10",EnKucukPuan="250",EnBuyukPuan="350",UserlId="deneme"}
            };

            foreach (var item in tercihler)
            {
                context.Tercihler.Add(item);
            }
            context.SaveChanges();
            List<TercihVeriModel> tercihVerileri = new List<TercihVeriModel>()
            {
                new TercihVeriModel(){ProgramKodu="11111111",ProgramAdi="sdü bilgisayar",PuanTuru="mf",Kontenjan="15",Yerlesen="10",EnKucukPuan="250",EnBuyukPuan="350"}
            };

            foreach (var item in tercihVerileri)
            {
                context.TercihVerileri.Add(item);
            }
            context.SaveChanges();



            base.Seed(context);
        }
    }
}