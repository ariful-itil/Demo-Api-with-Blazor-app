using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchInfo
{

	public record DeleteBranchInfo(string BranchCode): IRequest<ResultViewModel>;

}
