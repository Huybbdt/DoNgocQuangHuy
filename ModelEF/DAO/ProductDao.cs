using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
   public class ProductDao
    {
        DoNgocQuangHuyDbContext db = null;
        public ProductDao()
        {
            db = new DoNgocQuangHuyDbContext();
        }
        public long Insert(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var pro = db.Product.Find(entity.ID);
                pro.Name = entity.Name;
                pro.UnitCost = entity.UnitCost;
                pro.Quantity = entity.Quantity;
                pro.Status = entity.Status;
                pro.ProductType = entity.ProductType;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public Product GetByID(string name)
        {
            return db.Product.SingleOrDefault(x => x.Name == name);
        }
        public Product ViewDetail(int id)
        {
            return db.Product.Find(id);
        }
        public List<Product> ListAll()
        {
          return db.Product.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var name = db.Product.Find(id);
                db.Product.Remove(name);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //public List<Product> List()
        //{
        //    return db.Product.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        //}
        public Product Find(long id)
        {
            return db.Product.Find(id);
        }

    }
}

