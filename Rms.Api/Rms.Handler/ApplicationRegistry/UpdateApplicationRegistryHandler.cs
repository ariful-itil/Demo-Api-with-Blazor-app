using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicationRegistry;

namespace Handler.ApplicationRegistry
{
	public class UpdateApplicationRegistryHandler : IRequestHandler<UpdateApplicationRegistry, ResultViewModel>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public UpdateApplicationRegistryHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<ResultViewModel> Handle(UpdateApplicationRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
