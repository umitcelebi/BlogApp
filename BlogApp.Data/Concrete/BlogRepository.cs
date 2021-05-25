using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrete
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext context;
        public BlogRepository(BlogContext _context)
        {
            context = _context;
        }
        public void Add(Blog entity)
        {
            entity.AddedDate = DateTime.Now;
            entity.LastUpdatedDate = DateTime.Now;

            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Blogs.FirstOrDefault(b => b.BLogId == id);
            if (result != null)
            {
                context.Blogs.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<Blog> GetAll() => context.Blogs.AsQueryable();

        public IQueryable<Blog> GetByCategory(int id) => context.Blogs.Where(b=>b.CategoryId==id);

        public Blog GetById(int id) => context.Blogs.FirstOrDefault(b=>b.BLogId==id);

        public void Update(Blog entity)
        {
            var blog = context.Blogs.FirstOrDefault(b => b.BLogId == entity.BLogId);
            if (blog != null)
            {
                blog.Title = entity.Title;
                blog.Body = entity.Body;
                blog.Description = entity.Description;
                blog.Image = entity.Image;
                blog.IsApproved = entity.IsApproved;
                blog.IsSlider = entity.IsSlider;
                blog.IsHome = entity.IsHome;
                blog.CategoryId = entity.CategoryId;
                blog.LastUpdatedDate = DateTime.Now;
                context.SaveChanges();
            }
        }
        public IQueryable<Blog> Search(String q)
        {
            return context.Blogs.Where(b=>b.Body.Contains(q)||b.Description.Contains(q) || b.Title.Contains(q));
        }
    }
}
