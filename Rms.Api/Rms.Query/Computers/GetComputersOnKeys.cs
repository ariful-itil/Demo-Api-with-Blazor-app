using MediatR;
using System.Linq.Expressions;namespace Queries.Computers
{

	public record GetComputersOnKeys(Int32 SLNo): IRequest<IQueryable<Rms.Models.Computers>>;

}
