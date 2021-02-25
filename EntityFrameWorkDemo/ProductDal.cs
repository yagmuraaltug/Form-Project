using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.ToList();
            }
        }

        public List<Product> GetByName(string key)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList(); //veri tabani sorgulaniyor.
            }
        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList(); //veri tabani sorgulaniyor.
            }
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (EtradeContext context = new EtradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList(); //veri tabani sorgulaniyor.
            }
        }

        public Product GetById(int id)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }

        public void Add(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void Delete(Product product)
        {
            using (EtradeContext context = new EtradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

    }
}
