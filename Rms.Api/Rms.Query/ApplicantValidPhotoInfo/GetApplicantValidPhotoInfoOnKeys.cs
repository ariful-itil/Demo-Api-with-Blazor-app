using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantValidPhotoInfo
{

	public record GetApplicantValidPhotoInfoOnKeys(Int32 SlNumber): IRequest<IQueryable<Rms.Models.ApplicantValidPhotoInfo>>;

}
