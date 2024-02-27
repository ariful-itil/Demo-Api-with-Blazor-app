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
	public class UpdateExchangeRateInfoHandler : IRequestHandler<UpdateExchangeRateInfo, ResultViewModel>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public UpdateExchangeRateInfoHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<ResultViewModel> Handle(UpdateExchangeRateInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
