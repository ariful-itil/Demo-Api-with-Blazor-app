using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.FeesInfo
{

	public record SaveUpdateFeesInfo(Expression<Func<Rms.Models.FeesInfo,bool>>expression,Rms.Models.FeesInfo Model): IRequest<ResultViewModel>;

}
