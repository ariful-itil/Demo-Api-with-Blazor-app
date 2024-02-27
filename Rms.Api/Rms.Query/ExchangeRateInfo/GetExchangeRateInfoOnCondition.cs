using MediatR;
using System.Linq.Expressions;namespace Queries.ExchangeRateInfo
{

	public record GetExchangeRateInfoOnCondition(Expression<Func<Rms.Models.ExchangeRateInfo, bool>> expression): IRequest<IQueryable<Rms.Models.ExchangeRateInfo>>;

}
