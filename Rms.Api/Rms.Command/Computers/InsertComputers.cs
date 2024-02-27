using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Computers
{

	public record InsertComputers(Rms.Models.Computers Model): IRequest<ResultViewModel>;

}
