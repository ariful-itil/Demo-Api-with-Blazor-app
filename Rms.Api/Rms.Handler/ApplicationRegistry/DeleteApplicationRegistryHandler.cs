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
	public class DeleteApplicationRegistryHandler : IRequestHandler<DeleteApplicationRegistry, ResultViewModel>
	{
		private readonly IApplicationRegistry iapplicationregistry;
		public DeleteApplicationRegistryHandler(IApplicationRegistry _iapplicationregistry)
		{
			iapplicationregistry = _iapplicationregistry;
		}
		public async Task<ResultViewModel> Handle(DeleteApplicationRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicationregistry.DeleteAsync(x=> x.CountryCode == request.CountryCode & x.BankCode == request.BankCode & x.RegistryKey == request.RegistryKey);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
