using System.Linq.Expressions;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {


        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var data = await db.Set<T>().Where(expression).ToListAsync();
  
                return data.AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
