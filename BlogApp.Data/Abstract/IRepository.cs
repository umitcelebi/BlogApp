using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Abstract
{
    public interface IRepository <T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
