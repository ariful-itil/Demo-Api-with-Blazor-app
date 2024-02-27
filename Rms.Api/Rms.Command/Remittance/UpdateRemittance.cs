using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Remittance
{

	public record UpdateRemittance(Rms.Models.Remittance Model): IRequest<ResultViewModel>;

}
