using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.CommonCode
{

	public record UpdateCommonCode(Rms.Models.CommonCode Model): IRequest<ResultViewModel>;

}
