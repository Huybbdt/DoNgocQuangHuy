using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        DoNgocQuangHuyDbContext db = null;
        public CategoryDao()
        {
            db = new DoNgocQuangHuyDbContext();
        }
        public long Insert(Category entity)
        {
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Category.Find(entity.ID);
                cate.Name = entity.Name;
                cate.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public Category GetByID(string name)
        {
            return db.Category.SingleOrDefault(x => x.Name == name);
        }
        public Category ViewDetail(int id)
        {
            return db.Category.Find(id);
        }
        public List<Category> ListAll()
        {
            return db.Category.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var name = db.Category.Find(id);
                db.Category.Remove(name);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
