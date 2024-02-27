using MediatR;
using System.Linq.Expressions;namespace Queries.CommonCode
{

	public record GetCommonCodeOnKeys(string BankCode,string Code): IRequest<IQueryable<Rms.Models.CommonCode>>;

}
