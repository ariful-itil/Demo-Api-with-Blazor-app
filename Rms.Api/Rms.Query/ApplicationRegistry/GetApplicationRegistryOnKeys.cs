using MediatR;
using System.Linq.Expressions;namespace Queries.ApplicationRegistry
{

	public record GetApplicationRegistryOnKeys(string CountryCode,string BankCode,string RegistryKey): IRequest<IQueryable<Rms.Models.ApplicationRegistry>>;

}
