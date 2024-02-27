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
	public class InsertBranchRegistryHandler : IRequestHandler<InsertBranchRegistry, ResultViewModel>
	{
		private readonly IBranchRegistry ibranchregistry;
		public InsertBranchRegistryHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<ResultViewModel> Handle(InsertBranchRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
