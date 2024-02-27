using MediatR;
using System.Linq.Expressions;namespace Queries.Remittance
{

	public record GetAllRemittance(): IRequest<IQueryable<Rms.Models.Remittance>>;

}
