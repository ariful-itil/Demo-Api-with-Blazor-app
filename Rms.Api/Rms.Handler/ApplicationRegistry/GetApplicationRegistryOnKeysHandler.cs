using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicationRegistry;

namespace Handler.ApplicationRegistry
{
	public class GetApplicationRegistryOnKeysHandler : IRequestHandler<GetApplicationRegistryOnKeys, IQueryable<Rms.Models.ApplicationRegistry>>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public GetApplicationRegistryOnKeysHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<IQueryable<Rms.Models.ApplicationRegistry>> Handle(GetApplicationRegistryOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.FindByConditionAsync(x=> x.CountryCode == request.CountryCode & x.BankCode == request.BankCode & x.RegistryKey == request.RegistryKey);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
