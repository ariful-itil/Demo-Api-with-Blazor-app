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
	public class SaveUpdateBranchInfoHandler : IRequestHandler<SaveUpdateBranchInfo, ResultViewModel>
	{
		private readonly IBranchInfo ibranchinfo;
		public SaveUpdateBranchInfoHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateBranchInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
