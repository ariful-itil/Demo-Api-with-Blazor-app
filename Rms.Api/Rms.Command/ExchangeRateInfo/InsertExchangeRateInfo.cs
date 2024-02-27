using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ExchangeRateInfo
{

	public record InsertExchangeRateInfo(Rms.Models.ExchangeRateInfo Model): IRequest<ResultViewModel>;

}
