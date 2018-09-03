using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stronka.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}