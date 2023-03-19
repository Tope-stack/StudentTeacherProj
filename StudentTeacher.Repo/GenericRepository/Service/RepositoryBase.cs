using Microsoft.EntityFrameworkCore;
using StudentTeacher.Repo.Data;
using StudentTeacher.Repo.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Repo.GenericRepository.Service
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext) =>
            RepositoryContext = repositoryContext;


        public async Task CreateAsync(T entity) =>
            await Task.Run(() => RepositoryContext.Set<T>().Add(entity));
       

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges) =>
            !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>()
                .AsNoTracking()) : await Task.Run(() => RepositoryContext.Set<T>());
        

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) => 
            !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>().Where(expression)
                .AsNoTracking()) : await Task.Run(() => RepositoryContext.Set<T>().Where(expression));
       

        public async Task RemoveAsync(T entity) => 
            await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));


        public async Task UpdateAsync(T entity) =>
            await Task.Run(() => RepositoryContext.Set<T>().Update(entity));
        
    }
}
