using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.BranchInfo;

namespace Handler.BranchInfo
{
	public class GetBranchInfoOnKeysHandler : IRequestHandler<GetBranchInfoOnKeys, IQueryable<Rms.Models.BranchInfo>>
	{
		private readonly IBranchInfo ibranchinfo;
		public GetBranchInfoOnKeysHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<IQueryable<Rms.Models.BranchInfo>> Handle(GetBranchInfoOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.FindByConditionAsync(x=> x.BranchCode == request.BranchCode);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
