using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Stronka.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public Image Image { get; set; }
        public int Score { get; set; }
        public string IP { get; set; }
    }

    

}