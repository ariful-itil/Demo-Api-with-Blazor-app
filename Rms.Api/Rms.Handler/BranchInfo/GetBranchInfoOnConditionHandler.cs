using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.BranchInfo;

namespace Handler.BranchInfo
{
	public class GetBranchInfoOnConditionHandler : IRequestHandler<GetBranchInfoOnCondition, IQueryable<Rms.Models.BranchInfo>>
	{
		private readonly IBranchInfo ibranchinfo;
		public GetBranchInfoOnConditionHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<IQueryable<Rms.Models.BranchInfo>> Handle(GetBranchInfoOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
