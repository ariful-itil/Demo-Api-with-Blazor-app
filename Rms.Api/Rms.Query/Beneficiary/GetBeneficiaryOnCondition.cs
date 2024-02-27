using MediatR;
using System.Linq.Expressions;namespace Queries.Beneficiary
{

	public record GetBeneficiaryOnCondition(Expression<Func<Rms.Models.Beneficiary, bool>> expression): IRequest<IQueryable<Rms.Models.Beneficiary>>;

}
