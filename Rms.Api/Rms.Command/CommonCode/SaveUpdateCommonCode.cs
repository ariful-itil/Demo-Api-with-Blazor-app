using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.CommonCode
{

	public record SaveUpdateCommonCode(Expression<Func<Rms.Models.CommonCode,bool>>expression,Rms.Models.CommonCode Model): IRequest<ResultViewModel>;

}
