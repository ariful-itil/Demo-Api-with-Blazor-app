using System.Linq.Expressions;
using Interfaces;
using Logger;
using ViewModels;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public async Task<ResultViewModel> SaveUpdateAsync(Expression<Func<T, bool>> expression,T entity)
        {
            CustomLog.FunctionName = this.ToString();
            CustomLog.CorrelationId = null;
            var result = new ResultViewModel();
            try
            {
                var data = await FindByConditionAsync(expression);
                if (data.Any())
                {
                    var ExData = data.First();
                    db.Entry(ExData).CurrentValues.SetValues(entity);
                    await db.SaveChangesAsync();

                    CustomLog.Message = "Data Update Successfully";
                    CustomLog.Properties = ExData;
                    result.StatusCode = 200;
                    result.Description = $"{this.ToString()} Data Delete Successfully";

                    Logger.Information(CustomLog);
                }
                else
                {
                    db.Set<T>().Add(entity);
                    await db.SaveChangesAsync();

                    CustomLog.Message = "Data Saved Successfully";
                    CustomLog.Properties = entity;
                    result.StatusCode = 200;
                    result.Description = $"{this.ToString()} Data Saved Successfully";

                    Logger.Information(CustomLog);
                }
                return result;
            }
            catch (Exception ex)
            {
                CustomLog.Message = ex.ToString();

                Logger.Error(CustomLog);
                result.StatusCode = 500;
                result.Description = $"{this.ToString()} Failed to save data{ex.ToString()}";

                return result;
            }
        }
    }
}
