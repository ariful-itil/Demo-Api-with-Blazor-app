using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ExchangeRateInfo
{

	public record DeleteExchangeRateInfo(string BranchCode,DateOnly TransDate,string CurrencyCode,byte SLNO,string ExchangeRateType): IRequest<ResultViewModel>;

}
