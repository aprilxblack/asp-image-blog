using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Stronka.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public float AvgScore { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

        public Image() { }

        public Image(string url, string title = null)
        {
            Url = url;
            Title = title ?? "Image"; 
        }
    }

}