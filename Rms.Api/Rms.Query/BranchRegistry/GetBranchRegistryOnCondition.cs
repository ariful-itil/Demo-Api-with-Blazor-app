using MediatR;
using System.Linq.Expressions;namespace Queries.BranchRegistry
{

	public record GetBranchRegistryOnCondition(Expression<Func<Rms.Models.BranchRegistry, bool>> expression): IRequest<IQueryable<Rms.Models.BranchRegistry>>;

}
