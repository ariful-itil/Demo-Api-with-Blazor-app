using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicationRegistry
{

	public record GetApplicationRegistryOnCondition(Expression<Func<Rms.Models.ApplicationRegistry, bool>> expression): IRequest<IQueryable<Rms.Models.ApplicationRegistry>>;

}
