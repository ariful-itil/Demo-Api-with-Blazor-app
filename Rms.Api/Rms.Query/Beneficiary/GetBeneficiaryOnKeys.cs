using MediatR;
using System.Linq.Expressions;namespace Queries.Beneficiary
{

	public record GetBeneficiaryOnKeys(string BranchCode,string AGEXIDNO,Int16 SerialNo): IRequest<IQueryable<Rms.Models.Beneficiary>>;

}
