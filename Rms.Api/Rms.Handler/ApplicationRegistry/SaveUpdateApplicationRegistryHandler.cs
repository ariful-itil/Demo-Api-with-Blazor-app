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
	public class SaveUpdateApplicationRegistryHandler : IRequestHandler<SaveUpdateApplicationRegistry, ResultViewModel>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public SaveUpdateApplicationRegistryHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateApplicationRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
