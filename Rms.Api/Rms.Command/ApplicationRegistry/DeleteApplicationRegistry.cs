using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.ApplicationRegistry
{

	public record DeleteApplicationRegistry(string CountryCode,string BankCode,string RegistryKey): IRequest<ResultViewModel>;

}
