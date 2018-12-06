using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TercihRobotumBuSonOlsun.Models
{
    public class PuanHesaplaModel
    {
        public double diplomaNotu { get; set; }
        public int turkceDogru { get; set; }
        public int turkceYanlis { get; set; }
        public int sosyalDogru { get; set; }
        public int sosyalYanlis { get; set; }
        public int matematikDogru { get; set; }
        public int matematikYanlis { get; set; }
        public int fenDogru { get; set; }
        public int fenYanlis { get; set; }
    }
}