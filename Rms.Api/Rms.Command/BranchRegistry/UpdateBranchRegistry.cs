using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchRegistry
{

	public record UpdateBranchRegistry(Rms.Models.BranchRegistry Model): IRequest<ResultViewModel>;

}
