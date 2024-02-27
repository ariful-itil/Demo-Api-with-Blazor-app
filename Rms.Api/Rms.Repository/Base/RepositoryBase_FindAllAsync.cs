using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        public async Task<IQueryable<T>> FindAllAsync()
        {
            try
            {
                var data = await db.Set<T>().ToListAsync();
                return data.AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
