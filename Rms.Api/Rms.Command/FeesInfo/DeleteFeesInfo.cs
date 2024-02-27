using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.FeesInfo
{

	public record DeleteFeesInfo(string BranchCode,string AccountType,string TransType,byte SLNO): IRequest<ResultViewModel>;

}
