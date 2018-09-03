using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Stronka.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public Image Image { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

}