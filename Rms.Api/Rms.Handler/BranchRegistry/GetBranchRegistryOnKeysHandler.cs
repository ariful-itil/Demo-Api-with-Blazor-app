using Rms.Models;
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
	public class GetBranchRegistryOnKeysHandler : IRequestHandler<GetBranchRegistryOnKeys, IQueryable<Rms.Models.BranchRegistry>>
	{
		private readonly IBranchRegistry ibranchregistry;
		public GetBranchRegistryOnKeysHandler(IBranchRegistry _ibranchregistry)
		{
			ibranchregistry = _ibranchregistry;
		}
		public async Task<IQueryable<Rms.Models.BranchRegistry>> Handle(GetBranchRegistryOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchregistry.FindByConditionAsync(x=> x.BranchCode == request.BranchCode & x.RegistryKey == request.RegistryKey);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
