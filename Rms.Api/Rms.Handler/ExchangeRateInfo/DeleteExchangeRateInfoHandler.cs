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
	public class DeleteExchangeRateInfoHandler : IRequestHandler<DeleteExchangeRateInfo, ResultViewModel>
	{
		private readonly IExchangeRateInfo iexchangerateinfo;
		public DeleteExchangeRateInfoHandler(IExchangeRateInfo _iexchangerateinfo)
		{
			iexchangerateinfo = _iexchangerateinfo;
		}
		public async Task<ResultViewModel> Handle(DeleteExchangeRateInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iexchangerateinfo.DeleteAsync(x=> x.BranchCode == request.BranchCode & x.TransDate == request.TransDate & x.CurrencyCode == request.CurrencyCode & x.SLNO == request.SLNO & x.ExchangeRateType == request.ExchangeRateType);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
