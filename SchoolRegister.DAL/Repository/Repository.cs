﻿using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolRegister.DAL.Repository
{
    //Root repository
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private DbSet<TEntity> dbSet;
        public Repository(DatabaseContext context)
        {
            _context = context;//?? throw new ArgumentNullException(nameof(context));
            dbSet = _context.Set<TEntity>();
        }

        public double Average(Func<TEntity, double> filter)
        {
            return dbSet.Average(filter);
        }

        
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).ToListAsync();
        }

        

        public TEntity GetFirstOrDefault(Func<TEntity, bool> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public TEntity GetSingleOrDefault(Func<TEntity, bool> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        public Task<TEntity> GetSingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.SingleOrDefaultAsync(filter);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void InsertRange(List<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }

}