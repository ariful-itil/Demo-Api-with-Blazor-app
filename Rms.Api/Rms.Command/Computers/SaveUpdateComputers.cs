using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Computers
{

	public record SaveUpdateComputers(Expression<Func<Rms.Models.Computers,bool>>expression,Rms.Models.Computers Model): IRequest<ResultViewModel>;

}
