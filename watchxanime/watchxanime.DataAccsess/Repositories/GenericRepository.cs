using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using watchxanime.DataAccsess.Abstract;
using watchxanime.DataAccsess.Context;

namespace watchxanime.DataAccsess.Repositories
{
    public class GenericRepository<T>(watchxanimeContext _context) : IRepository<T> where T : class 
    {
        public DbSet<T> Table { get => _context.Set<T>(); }
        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }
        public T GetById(int id)
        {
            return Table.Find(id);
        }
        public void Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }
        public List<T> GetList()
        {
            return Table.ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault();
        }
        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }
    }
}
