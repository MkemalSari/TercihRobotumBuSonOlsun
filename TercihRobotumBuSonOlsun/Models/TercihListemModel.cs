using System.Collections.Generic;
using TercihimNihaiProje.Models;

namespace TercihRobotumBuSonOlsun.Models
{
    public class TercihListemModel
    {
      
        public int  Id { get; set; }
        public string ad { get; set; }

       List<MyViewModel> Tercihler { get; set; }

    }
}