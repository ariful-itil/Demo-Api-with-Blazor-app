using System.Linq.Expressions;

using Interfaces;
using Logger;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using Rms.Models;


namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly Entity db;
        private readonly ICustomLogger Logger;
        private readonly IServiceProvider Provider;
        private CustomLog CustomLog = new CustomLog();
        public RepositoryBase(IServiceProvider _provider)
        {
            Provider = _provider;
            db = Provider.CreateScope().ServiceProvider.GetRequiredService<Entity>();
            Logger = Provider.CreateScope().ServiceProvider.GetRequiredService<ICustomLogger>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            try
            {
                var data = db.Set<T>().Where(expression).ToList(); 
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
