using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace SCS.Services
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private MyDbContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository()
        {
            _context = new MyDbContext();
            _dbSet = _context.Set<T>();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    }
}
