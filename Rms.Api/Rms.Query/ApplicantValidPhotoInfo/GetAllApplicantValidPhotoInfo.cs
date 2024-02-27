using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantValidPhotoInfo
{

	public record GetAllApplicantValidPhotoInfo(): IRequest<IQueryable<Rms.Models.ApplicantValidPhotoInfo>>;

}
