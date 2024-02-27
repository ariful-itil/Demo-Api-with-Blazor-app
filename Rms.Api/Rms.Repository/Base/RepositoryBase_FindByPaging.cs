using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using ViewModels;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    { 
        public async Task<IQueryable<T>> FindByConditionPaging(Expression<Func<T, bool>> expression, Pagination pg)
        {
            try
            {
                var Rec=db.Set<T>().Where(expression).Count();
                int TotalPage = Convert.ToInt32( Rec / pg.row_per_page);
                int Rest =Convert.ToInt32( Rec % pg.row_per_page);
                if (Rest > 0)
                    TotalPage = TotalPage + 1;
                if (pg.page_no > TotalPage)
                    pg.page_no = TotalPage;
                else if (pg.page_no < 1)
                    pg.page_no = 1;

                Paging.pages = TotalPage;
                Paging.rows = Rec;
                
                var data =await db.Set<T>().Where(expression).Skip((pg.page_no - 1) * pg.row_per_page).Take(pg.row_per_page).ToListAsync(); 
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
