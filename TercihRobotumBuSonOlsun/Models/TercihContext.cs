using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TercihimNihaiProje.Models;

namespace TercihRobotumBuSonOlsun.Models
{
    public class TercihContext: DbContext
    {
        public TercihContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new TercihInitializer());
        }

        public DbSet< MyViewModel> Tercihler { get; set; }
        public DbSet<TercihVeriModel> TercihVerileri { get; set; }

    }
}