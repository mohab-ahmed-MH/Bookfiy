using Bookfiy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiy.EF.Repositeries
{
    public class BaseRepositoty<T> : IBaseRepositoty<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepositoty(ApplicationDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public T Delete(int id, T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return entity ;
        }

    }
}
