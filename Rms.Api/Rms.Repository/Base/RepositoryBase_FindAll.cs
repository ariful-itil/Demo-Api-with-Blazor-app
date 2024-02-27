using Interfaces;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
          public IQueryable<T> FindAll()
        {
            try
            {
                var data = db.Set<T>().ToList();   
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
