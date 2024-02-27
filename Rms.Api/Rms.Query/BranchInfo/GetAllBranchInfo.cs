using MediatR;
using System.Linq.Expressions;namespace Queries.BranchInfo
{

	public record GetAllBranchInfo(): IRequest<IQueryable<Rms.Models.BranchInfo>>;

}
