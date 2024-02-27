using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchInfo
{

	public record SaveUpdateBranchInfo(Expression<Func<Rms.Models.BranchInfo,bool>>expression,Rms.Models.BranchInfo Model): IRequest<ResultViewModel>;

}
