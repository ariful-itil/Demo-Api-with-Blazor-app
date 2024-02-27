using MediatR;
using System.Linq.Expressions;namespace Queries.CommonCode
{

	public record GetCommonCodeOnCondition(Expression<Func<Rms.Models.CommonCode, bool>> expression): IRequest<IQueryable<Rms.Models.CommonCode>>;

}
