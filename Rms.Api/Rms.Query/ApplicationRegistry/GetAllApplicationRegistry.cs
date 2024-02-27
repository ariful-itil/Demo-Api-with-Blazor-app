using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicationRegistry
{

	public record GetAllApplicationRegistry(): IRequest<IQueryable<Rms.Models.ApplicationRegistry>>;

}
