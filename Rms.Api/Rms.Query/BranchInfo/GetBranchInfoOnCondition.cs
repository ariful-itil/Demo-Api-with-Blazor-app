using MediatR;
using System.Linq.Expressions;namespace Queries.BranchInfo
{

	public record GetBranchInfoOnCondition(Expression<Func<Rms.Models.BranchInfo, bool>> expression): IRequest<IQueryable<Rms.Models.BranchInfo>>;

}
