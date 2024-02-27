using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ExchangeRateInfo;

namespace Handler.ExchangeRateInfo
{
	public class GetExchangeRateInfoOnConditionHandler : IRequestHandler<GetExchangeRateInfoOnCondition, IQueryable<Rms.Models.ExchangeRateInfo>>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public GetExchangeRateInfoOnConditionHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<IQueryable<Rms.Models.ExchangeRateInfo>> Handle(GetExchangeRateInfoOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
