using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Abstract
{
    public interface IBlogRepository:IRepository<Blog>
    {
        IQueryable<Blog> GetByCategory(int id);
        IQueryable<Blog> Search(String q);
    }
}
