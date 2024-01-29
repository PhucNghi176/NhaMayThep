using NhaMapThep.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace NhaMapThep.Domain.Repositories
{
    public interface IEFRepository<TDomain, TPersistence> : IRepository<TDomain>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TDomain?> FindAnyAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<TDomain?> FindAsync(Expression<Func<TPersistence, bool>> filterExpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<TDomain?> FindAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);

        Task<List<TDomain>> FindAllAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<List<TProjection>> FindAllProjectToAsync<TProjection>(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<IPagedResult<TProjection>> FindAllProjectToAsync<TProjection>(int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<TProjection?> FindProjectToAsync<TProjection>(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);

        // write a method to return a dictionary of key value pair
        //         // where key is the id of type int and value is the name of type string  
        // for example, Dictionary<int, string> where int is the id and string is the name  
        // this method will be used to populate dropdownlist  
       Task<Dictionary<TKey,TValue>> FindAllToDictionaryAsync<TKey,TValue>(
           Expression<Func<TPersistence, bool>> filterExpression,
           Expression<Func<TPersistence, TKey>> keySelector,
           Expression<Func<TPersistence, TValue>> valueSelector, 
           CancellationToken cancellationToken = default);

    }
}
