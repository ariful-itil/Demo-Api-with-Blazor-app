using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.BranchRegistry;

namespace Handler.BranchRegistry
{
	public class GetBranchRegistryOnConditionHandler : IRequestHandler<GetBranchRegistryOnCondition, IQueryable<Rms.Models.BranchRegistry>>
	{
		private readonly IBranchRegistry ibranchregistry;
		public GetBranchRegistryOnConditionHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<IQueryable<Rms.Models.BranchRegistry>> Handle(GetBranchRegistryOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
