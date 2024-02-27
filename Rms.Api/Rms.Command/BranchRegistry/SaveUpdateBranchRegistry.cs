using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchRegistry
{

	public record SaveUpdateBranchRegistry(Expression<Func<Rms.Models.BranchRegistry,bool>>expression,Rms.Models.BranchRegistry Model): IRequest<ResultViewModel>;

}
