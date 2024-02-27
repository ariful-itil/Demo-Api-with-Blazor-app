using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Beneficiary
{

	public record InsertBeneficiary(Rms.Models.Beneficiary Model): IRequest<ResultViewModel>;

}
