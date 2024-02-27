using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicationRegistry
{

	public record UpdateApplicationRegistry(Rms.Models.ApplicationRegistry Model): IRequest<ResultViewModel>;

}
