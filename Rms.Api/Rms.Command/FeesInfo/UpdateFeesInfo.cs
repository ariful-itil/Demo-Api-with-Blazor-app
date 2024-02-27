using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.FeesInfo
{

	public record UpdateFeesInfo(Rms.Models.FeesInfo Model): IRequest<ResultViewModel>;

}
