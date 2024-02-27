using MediatR;
using System.Linq.Expressions;namespace Queries.Remittance
{

	public record GetRemittanceOnKeys(Int64 IdentityNo): IRequest<IQueryable<Rms.Models.Remittance>>;

}
