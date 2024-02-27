using MediatR;
using System.Linq.Expressions;namespace Queries.Remittance
{

	public record GetRemittanceOnCondition(Expression<Func<Rms.Models.Remittance, bool>> expression): IRequest<IQueryable<Rms.Models.Remittance>>;

}
