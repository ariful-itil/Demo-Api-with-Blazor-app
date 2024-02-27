using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.BranchRegistry;

namespace Handler.BranchRegistry
{
	public class UpdateBranchRegistryHandler : IRequestHandler<UpdateBranchRegistry, ResultViewModel>
	{
		private readonly IBranchRegistry ibranchregistry;
		public UpdateBranchRegistryHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<ResultViewModel> Handle(UpdateBranchRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
