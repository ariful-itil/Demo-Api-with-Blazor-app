using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Beneficiary
{

	public record SaveUpdateBeneficiary(Expression<Func<Rms.Models.Beneficiary,bool>>expression,Rms.Models.Beneficiary Model): IRequest<ResultViewModel>;

}
