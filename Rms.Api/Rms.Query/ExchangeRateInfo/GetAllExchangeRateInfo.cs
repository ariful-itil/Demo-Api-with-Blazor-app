using MediatR;
using System.Linq.Expressions;namespace Queries.ExchangeRateInfo
{

	public record GetAllExchangeRateInfo(): IRequest<IQueryable<Rms.Models.ExchangeRateInfo>>;

}
