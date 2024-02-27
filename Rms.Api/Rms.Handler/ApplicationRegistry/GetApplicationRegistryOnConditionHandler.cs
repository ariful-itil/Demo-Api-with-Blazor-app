using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicationRegistry;

namespace Handler.ApplicationRegistry
{
	public class GetApplicationRegistryOnConditionHandler : IRequestHandler<GetApplicationRegistryOnCondition, IQueryable<Rms.Models.ApplicationRegistry>>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public GetApplicationRegistryOnConditionHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<IQueryable<Rms.Models.ApplicationRegistry>> Handle(GetApplicationRegistryOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
