using GoldenSmith.Domain.Entities;
using GoldenSmith.Domain.Repositories;
using GoldenSmith.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Infrastructure.Repositories
{
    public class Repo<T>:IRepo<T> where T : class, new()
    {
        private readonly JewelryDbContext _context;
        protected DbSet<T> _dbSet;
        public Repo(JewelryDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll() 
        { 
            return _dbSet.ToList();
        }

        public T Get(int id) 
        {
            return _dbSet.Find(id);
        }

        public bool Add(T entity)
        {
            bool flag = false;
            if (!_dbSet.Any(e => e == entity))
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public bool Update(T entity) 
        {
            bool flag = true;
            if(!_dbSet.Any(e => e == entity))
            {
                flag = false;
            }
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException) { throw; }
            return flag;
        }

        public bool Delete(int id) 
        {
            bool flag = true;
            var entity = _dbSet.Find(id);
            if(entity == null) 
            {
                flag = false;
                return flag;
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return flag;
        }

    }
}
