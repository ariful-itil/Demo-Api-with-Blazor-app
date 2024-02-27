using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Computers
{

	public record UpdateComputers(Rms.Models.Computers Model): IRequest<ResultViewModel>;

}
