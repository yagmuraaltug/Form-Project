using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemo
{
    public class EtradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}
