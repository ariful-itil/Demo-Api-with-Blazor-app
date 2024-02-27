using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ExchangeRateInfo;

namespace Handler.ExchangeRateInfo
{
	public class InsertExchangeRateInfoHandler : IRequestHandler<InsertExchangeRateInfo, ResultViewModel>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public InsertExchangeRateInfoHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<ResultViewModel> Handle(InsertExchangeRateInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
