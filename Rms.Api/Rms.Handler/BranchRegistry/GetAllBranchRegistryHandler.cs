using  Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.BranchRegistry;

namespace Handler.BranchRegistry
{
	public class GetAllBranchRegistryHandler : IRequestHandler<GetAllBranchRegistry, IQueryable<Rms.Models.BranchRegistry>>
	{
		private readonly IBranchRegistry ibranchregistry;
		public GetAllBranchRegistryHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<IQueryable<Rms.Models.BranchRegistry>> Handle(GetAllBranchRegistry request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
