using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.DAL.Interface
{
	public interface IRepository<TEntity> where TEntity: class
	{

        void Insert(TEntity entity);
        void InsertRange(List<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        int Commit();
        Task<int> CommitAsync();

        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);

        TEntity GetFirstOrDefault(Func<TEntity, bool> filter);

		//Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter);
        TEntity GetSingleOrDefault(Func<TEntity, bool> filter);

		Task<TEntity> GetSingleOrDefault(Expression<Func<TEntity, bool>> filter);

        double Average(Func<TEntity, double> filter);

		
	}
}
