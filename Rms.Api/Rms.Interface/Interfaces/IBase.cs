using ViewModels;
using System.Linq.Expressions;

namespace Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindAllAsync();
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<ResultViewModel> SaveAsync(T entity);
        Task<ResultViewModel> UpdateAsync(T entity);
        Task<ResultViewModel> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<ResultViewModel> SaveUpdateAsync(Expression<Func<T, bool>> expression, T entity);

        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> FindByConditionPaging(Expression<Func<T, bool>> expression, Pagination pg);
        ResultViewModel Save(T entity);
        ResultViewModel Update(T entity);
        ResultViewModel Delete(Expression<Func<T, bool>> expression);
    }
}
