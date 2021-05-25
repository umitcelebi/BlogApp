using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private BlogContext context;
        public CategoryRepository(BlogContext _context)
        {
            context = _context;
        }
        public void Add(Category entity)
        {
            var result = context.Categories.SingleOrDefault(c => c.CategoryId == entity.CategoryId);

            if (result != null)
            {
                result.CategoryName = entity.CategoryName;
            }
            else
            {
                context.Categories.Add(entity);
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Categories.SingleOrDefault(c=>c.CategoryId==id);

            if (result != null)
            {
                context.Categories.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll() => context.Categories.AsQueryable();

        public Category GetById(int id) => context.Categories.SingleOrDefault(c=>c.CategoryId==id);

        public void Update(Category entity)
        {
            var result = context.Categories.SingleOrDefault(c=>c.CategoryId==entity.CategoryId);

            if (result != null)
            {
                result.CategoryName = entity.CategoryName;
                context.SaveChanges();
            }

        }
    }
}
