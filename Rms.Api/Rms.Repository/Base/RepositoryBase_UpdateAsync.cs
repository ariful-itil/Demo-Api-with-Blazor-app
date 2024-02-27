using Interfaces;
using Logger;
using ViewModels;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public async Task<ResultViewModel> UpdateAsync(T entity)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            var result = new ResultViewModel();
            try
            {
                db.Set<T>().Update(entity);
                await db.SaveChangesAsync();

                CustomLog.Message = "Data Updated Successfully";
                CustomLog.Properties = entity;
                result.StatusCode = 200;
                result.Description = $"{ToString()} Data Updated Successfully";
                Logger.Information(CustomLog);
            }
            catch (Exception ex)
            {
                CustomLog.Message = ex.ToString();
                CustomLog.Properties = entity;
                result.StatusCode = 500;
                result.Description = $"{ToString()} Data Update Failed";
                Logger.Error(CustomLog);
            }
            return result;
        }
    }
}
