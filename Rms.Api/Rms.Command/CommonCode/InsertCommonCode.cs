using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.CommonCode
{

	public record InsertCommonCode(Rms.Models.CommonCode Model): IRequest<ResultViewModel>;

}
