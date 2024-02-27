using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchInfo
{

	public record UpdateBranchInfo(Rms.Models.BranchInfo Model): IRequest<ResultViewModel>;

}
