using MediatR;
using System.Linq.Expressions;namespace Queries.BranchRegistry
{

	public record GetAllBranchRegistry(): IRequest<IQueryable<Rms.Models.BranchRegistry>>;

}
