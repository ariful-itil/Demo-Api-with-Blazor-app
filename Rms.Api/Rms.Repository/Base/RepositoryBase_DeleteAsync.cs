using System.Linq.Expressions;
using Interfaces;
using Logger;
using ViewModels;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public async Task<ResultViewModel> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            var result = new ResultViewModel();
            try
            {
                var data = await FindByConditionAsync(expression);
                if (data.Any())
                {
                    var ExData = data.First();
                    db.Set<T>().Remove(ExData);
                    await db.SaveChangesAsync();


                    CustomLog.Message = "Data Delete Successfully";
                    CustomLog.Properties = ExData;
                    result.StatusCode = 200;
                    result.Description = $"{ToString()} Data Delete Successfully";

                    Logger.Information(CustomLog);
                }
                return result;
            }
            catch (Exception ex)
            {
                CustomLog.Message = ex.ToString();

                Logger.Error(CustomLog);
                result.StatusCode = 500;
                result.Description = $"{ex.ToString()} Data Delete Failed";

                return result;
            }
        }
    }
}
