using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ExchangeRateInfo;

namespace Handler.ExchangeRateInfo
{
	public class GetExchangeRateInfoOnKeysHandler : IRequestHandler<GetExchangeRateInfoOnKeys, IQueryable<Rms.Models.ExchangeRateInfo>>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public GetExchangeRateInfoOnKeysHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<IQueryable<Rms.Models.ExchangeRateInfo>> Handle(GetExchangeRateInfoOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.FindByConditionAsync(x=> x.BranchCode == request.BranchCode & x.TransDate == request.TransDate & x.CurrencyCode == request.CurrencyCode & x.SLNO == request.SLNO & x.ExchangeRateType == request.ExchangeRateType);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
