using  Rms.Models;
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
	public class GetAllExchangeRateInfoHandler : IRequestHandler<GetAllExchangeRateInfo, IQueryable<Rms.Models.ExchangeRateInfo>>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public GetAllExchangeRateInfoHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<IQueryable<Rms.Models.ExchangeRateInfo>> Handle(GetAllExchangeRateInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
