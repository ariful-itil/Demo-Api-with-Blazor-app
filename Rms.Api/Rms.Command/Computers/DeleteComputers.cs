using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Computers
{

	public record DeleteComputers(Int32 SLNo): IRequest<ResultViewModel>;

}
