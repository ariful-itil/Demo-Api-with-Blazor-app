using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.BranchRegistry;

namespace Handler.BranchRegistry
{
	public class DeleteBranchRegistryHandler : IRequestHandler<DeleteBranchRegistry, ResultViewModel>
	{
		private readonly IBranchRegistry ibranchregistry;
		public DeleteBranchRegistryHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<ResultViewModel> Handle(DeleteBranchRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.DeleteAsync(x=> x.BranchCode == request.BranchCode & x.RegistryKey == request.RegistryKey);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
