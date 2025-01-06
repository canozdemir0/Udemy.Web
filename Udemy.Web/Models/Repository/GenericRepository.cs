﻿
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void SoftDelete(T entity)
        {
            var entitySoftDelete = entity as IAuditSoftDelete;
            entitySoftDelete.IsDeleted = true;
            _dbSet.Update(entity);
        }
    }
}
