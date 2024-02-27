using MediatR;
using System.Linq.Expressions;namespace Queries.Computers
{

	public record GetAllComputers(): IRequest<IQueryable<Rms.Models.Computers>>;

}
