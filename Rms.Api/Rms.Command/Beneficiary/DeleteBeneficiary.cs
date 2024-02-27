using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Beneficiary
{

	public record DeleteBeneficiary(string BranchCode,string AGEXIDNO,Int16 SerialNo): IRequest<ResultViewModel>;

}
