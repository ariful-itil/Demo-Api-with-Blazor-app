using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.BranchInfo;

namespace Handler.BranchInfo
{
	public class UpdateBranchInfoHandler : IRequestHandler<UpdateBranchInfo, ResultViewModel>
	{
		private readonly IBranchInfo ibranchinfo;
		public UpdateBranchInfoHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<ResultViewModel> Handle(UpdateBranchInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
