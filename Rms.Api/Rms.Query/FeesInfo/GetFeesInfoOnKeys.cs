using MediatR;
using System.Linq.Expressions;namespace Queries.FeesInfo
{

	public record GetFeesInfoOnKeys(string BranchCode,string AccountType,string TransType,byte SLNO): IRequest<IQueryable<Rms.Models.FeesInfo>>;

}
