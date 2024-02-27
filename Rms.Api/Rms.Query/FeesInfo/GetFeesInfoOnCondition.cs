using MediatR;
using System.Linq.Expressions;namespace Queries.FeesInfo
{

	public record GetFeesInfoOnCondition(Expression<Func<Rms.Models.FeesInfo, bool>> expression): IRequest<IQueryable<Rms.Models.FeesInfo>>;

}
