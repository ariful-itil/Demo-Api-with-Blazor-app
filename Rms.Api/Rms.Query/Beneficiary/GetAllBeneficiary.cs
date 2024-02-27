using MediatR;
using System.Linq.Expressions;namespace Queries.Beneficiary
{

	public record GetAllBeneficiary(): IRequest<IQueryable<Rms.Models.Beneficiary>>;

}
