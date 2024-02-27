using  Rms.Models;
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
	public class GetAllBranchInfoHandler : IRequestHandler<GetAllBranchInfo, IQueryable<Rms.Models.BranchInfo>>
	{
		private readonly IBranchInfo ibranchinfo;
		public GetAllBranchInfoHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<IQueryable<Rms.Models.BranchInfo>> Handle(GetAllBranchInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
