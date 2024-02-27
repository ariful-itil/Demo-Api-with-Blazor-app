using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.BranchInfo;

namespace Handler.BranchInfo
{
	public class InsertBranchInfoHandler : IRequestHandler<InsertBranchInfo, ResultViewModel>
	{
		private readonly IBranchInfo ibranchinfo;
		public InsertBranchInfoHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<ResultViewModel> Handle(InsertBranchInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
