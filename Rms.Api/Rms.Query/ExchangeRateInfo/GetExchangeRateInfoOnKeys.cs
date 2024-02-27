using MediatR;
using System.Linq.Expressions;namespace Queries.ExchangeRateInfo
{

	public record GetExchangeRateInfoOnKeys(string BranchCode,DateOnly TransDate,string CurrencyCode,byte SLNO,string ExchangeRateType): IRequest<IQueryable<Rms.Models.ExchangeRateInfo>>;

}
