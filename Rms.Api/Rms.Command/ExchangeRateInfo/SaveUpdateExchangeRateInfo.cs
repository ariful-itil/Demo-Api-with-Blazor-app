using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ExchangeRateInfo
{

	public record SaveUpdateExchangeRateInfo(Expression<Func<Rms.Models.ExchangeRateInfo,bool>>expression,Rms.Models.ExchangeRateInfo Model): IRequest<ResultViewModel>;

}
