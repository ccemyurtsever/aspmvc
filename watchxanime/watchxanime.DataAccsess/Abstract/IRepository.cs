using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.DataAccsess.Abstract
{ // methods 
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        int Count();
        int FilteredCount(Expression<Func<T, bool>> predicate); // onlıne or offlıne 
        List<T> GetFilteredList(Expression<Func<T, bool>> predicate);
    }
}
