using RecapProject1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapProject1
{
    public class NorthWindContext:DbContext
    {
        
       public DbSet<Product> Products { get; set; } //Bir ürünüm var ve bu Products tablosundaki ürüne karşılık gelmektedir.
        public DbSet<Category> Categories { get;set; }
    }
}
