using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicationRegistry
{

	public record SaveUpdateApplicationRegistry(Expression<Func<Rms.Models.ApplicationRegistry,bool>>expression,Rms.Models.ApplicationRegistry Model): IRequest<ResultViewModel>;

}
