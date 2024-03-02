using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core;
using Task.Core.Entities;
using Task.Infrastructure.Contracts;

namespace Task.Infrastructure.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int? id)
                  => await _context.Set<T>().FindAsync(id);
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public  T Update(T entity)
        //{
        //    _context.Update(entity);
        //    _context.SaveChanges();
        //    return entity;
        //}

        public async void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
                    => await _context.Set<T>().ToListAsync();


    }
}
