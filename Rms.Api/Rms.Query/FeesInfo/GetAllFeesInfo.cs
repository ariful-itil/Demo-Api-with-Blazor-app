using MediatR;
using System.Linq.Expressions;namespace Queries.FeesInfo
{

	public record GetAllFeesInfo(): IRequest<IQueryable<Rms.Models.FeesInfo>>;

}
