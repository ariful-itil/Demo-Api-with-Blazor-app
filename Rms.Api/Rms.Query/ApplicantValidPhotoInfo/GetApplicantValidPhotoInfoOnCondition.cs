using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantValidPhotoInfo
{

	public record GetApplicantValidPhotoInfoOnCondition(Expression<Func<Rms.Models.ApplicantValidPhotoInfo, bool>> expression): IRequest<IQueryable<Rms.Models.ApplicantValidPhotoInfo>>;

}
