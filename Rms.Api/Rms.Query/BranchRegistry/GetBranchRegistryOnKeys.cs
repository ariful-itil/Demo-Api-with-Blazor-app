using MediatR;
using System.Linq.Expressions;namespace Queries.BranchRegistry
{

	public record GetBranchRegistryOnKeys(string BranchCode,string RegistryKey): IRequest<IQueryable<Rms.Models.BranchRegistry>>;

}
