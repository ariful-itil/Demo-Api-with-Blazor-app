using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.Remittance
{

	public record DeleteRemittance(Int64 IdentityNo): IRequest<ResultViewModel>;

}
