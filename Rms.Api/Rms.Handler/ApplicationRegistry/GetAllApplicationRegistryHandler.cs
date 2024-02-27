using  Rms.Models;
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
	public class GetAllApplicationRegistryHandler : IRequestHandler<GetAllApplicationRegistry, IQueryable<Rms.Models.ApplicationRegistry>>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public GetAllApplicationRegistryHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<IQueryable<Rms.Models.ApplicationRegistry>> Handle(GetAllApplicationRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
