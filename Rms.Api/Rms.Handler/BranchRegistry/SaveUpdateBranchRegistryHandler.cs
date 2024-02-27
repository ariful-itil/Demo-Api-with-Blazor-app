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
	public class SaveUpdateBranchRegistryHandler : IRequestHandler<SaveUpdateBranchRegistry, ResultViewModel>
	{
		private readonly IBranchRegistry ibranchregistry;
		public SaveUpdateBranchRegistryHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateBranchRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
