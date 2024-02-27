using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantInfo
{

	public record GetAllApplicantInfo(): IRequest<IQueryable<Rms.Models.ApplicantInfo>>;

}
