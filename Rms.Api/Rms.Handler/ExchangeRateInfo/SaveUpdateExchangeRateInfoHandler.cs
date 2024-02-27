using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ExchangeRateInfo;

namespace Handler.ExchangeRateInfo
{
	public class SaveUpdateExchangeRateInfoHandler : IRequestHandler<SaveUpdateExchangeRateInfo, ResultViewModel>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public SaveUpdateExchangeRateInfoHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateExchangeRateInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
