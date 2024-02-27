using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantInfo
{

	public record GetApplicantInfoOnCondition(Expression<Func<Rms.Models.ApplicantInfo, bool>> expression): IRequest<IQueryable<Rms.Models.ApplicantInfo>>;

}
