using System.Linq.Expressions;
using Interfaces;
using Logger;
using ViewModels;

namespace Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public ResultViewModel Delete(Expression<Func<T, bool>> expression)
        {
            CustomLog.FunctionName = ToString();
            CustomLog.CorrelationId = null;
            var result = new ResultViewModel();
            try
            {
                var data = FindByCondition(expression);
                if (data.Any())
                {
                    var ExData = data.First();
                    db.Set<T>().Remove(ExData);
                    db.SaveChanges();


                    CustomLog.Message = "Data Delete Successfully";
                    CustomLog.Properties = ExData;
                    Logger.Information(CustomLog);
                    result.StatusCode = 200;
                    result.Description = $"{ToString()}Data Delete Successfully";
                }
                return result;
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Description = $"{ex.ToString()} Data Delete Failed";

                CustomLog.Message = ex.ToString();
                Logger.Error(CustomLog);
                return result;
            }
        }
    }
}
