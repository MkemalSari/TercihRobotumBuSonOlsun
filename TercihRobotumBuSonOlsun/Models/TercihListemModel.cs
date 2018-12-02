using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TercihimNihaiProje.Models;

namespace TercihRobotumBuSonOlsun.Models
{
    public class TercihListemModel
    {
       public int  Id { get; set; }
       public string ad { get; set; }

      public  List<MyViewModel> Model { get; set; }

    }
}