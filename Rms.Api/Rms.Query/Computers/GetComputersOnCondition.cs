using MediatR;
using System.Linq.Expressions;namespace Queries.Computers
{

	public record GetComputersOnCondition(Expression<Func<Rms.Models.Computers, bool>> expression): IRequest<IQueryable<Rms.Models.Computers>>;

}
