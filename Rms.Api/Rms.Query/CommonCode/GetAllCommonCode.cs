using MediatR;
using System.Linq.Expressions;namespace Queries.CommonCode
{

	public record GetAllCommonCode(): IRequest<IQueryable<Rms.Models.CommonCode>>;

}
