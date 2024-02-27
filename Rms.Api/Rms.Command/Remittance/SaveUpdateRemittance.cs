using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Remittance
{

	public record SaveUpdateRemittance(Expression<Func<Rms.Models.Remittance,bool>>expression,Rms.Models.Remittance Model): IRequest<ResultViewModel>;

}
