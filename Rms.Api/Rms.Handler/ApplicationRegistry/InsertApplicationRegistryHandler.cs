using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicationRegistry;

namespace Handler.ApplicationRegistry
{
	public class InsertApplicationRegistryHandler : IRequestHandler<InsertApplicationRegistry, ResultViewModel>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public InsertApplicationRegistryHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<ResultViewModel> Handle(InsertApplicationRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
