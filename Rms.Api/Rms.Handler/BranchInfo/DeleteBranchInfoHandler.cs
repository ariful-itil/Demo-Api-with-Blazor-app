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
	public class DeleteBranchInfoHandler : IRequestHandler<DeleteBranchInfo, ResultViewModel>
	{
		private readonly IBranchInfo ibranchinfo;
		public DeleteBranchInfoHandler(IBranchInfo _ibranchinfo)
		{
			ibranchinfo = _ibranchinfo;
		}
		public async Task<ResultViewModel> Handle(DeleteBranchInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibranchinfo.DeleteAsync(x=> x.BranchCode == request.BranchCode);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
