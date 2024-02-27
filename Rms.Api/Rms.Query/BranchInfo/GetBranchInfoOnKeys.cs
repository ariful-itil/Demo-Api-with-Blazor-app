using MediatR;
using System.Linq.Expressions;namespace Queries.BranchInfo
{

	public record GetBranchInfoOnKeys(string BranchCode): IRequest<IQueryable<Rms.Models.BranchInfo>>;

}
