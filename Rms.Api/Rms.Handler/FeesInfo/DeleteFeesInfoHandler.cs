using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.FeesInfo;

namespace Handler.FeesInfo
{
	public class DeleteFeesInfoHandler : IRequestHandler<DeleteFeesInfo, ResultViewModel>
	{
		private readonly IFeesInfo ifeesinfo;
		public DeleteFeesInfoHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<ResultViewModel> Handle(DeleteFeesInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.DeleteAsync(x=> x.BranchCode == request.BranchCode & x.AccountType == request.AccountType & x.TransType == request.TransType & x.SLNO == request.SLNO);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
