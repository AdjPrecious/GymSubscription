using Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task CreateAsync(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);
       

        public  void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);


        public IQueryable<T> FindAll() => RepositoryContext.Set<T>();
       

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression);


        public void Update(T entity) => RepositoryContext.Update(entity);

        public IQueryable<T> FindChild (Expression<Func<T, bool>> expression, T entity)=> RepositoryContext.Set<T>().Where(expression).Include(expression);
        
    }
}
