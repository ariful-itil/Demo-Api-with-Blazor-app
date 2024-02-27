using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.FeesInfo;

namespace Handler.FeesInfo
{
	public class GetFeesInfoOnKeysHandler : IRequestHandler<GetFeesInfoOnKeys, IQueryable<Rms.Models.FeesInfo>>
	{
		private readonly IFeesInfo ifeesinfo;
		public GetFeesInfoOnKeysHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<IQueryable<Rms.Models.FeesInfo>> Handle(GetFeesInfoOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.FindByConditionAsync(x=> x.BranchCode == request.BranchCode & x.AccountType == request.AccountType & x.TransType == request.TransType & x.SLNO == request.SLNO);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
