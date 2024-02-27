using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicantInfo
{

	public record GetApplicantInfoOnKeys(Int64 SerialNo): IRequest<IQueryable<Rms.Models.ApplicantInfo>>;

}
