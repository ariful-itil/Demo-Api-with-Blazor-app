using System;
using Rms.Models;
using ViewModels;
using System.Linq.Expressions;
using MediatR;

namespace Commands.BranchRegistry
{

	public record DeleteBranchRegistry(string BranchCode,string RegistryKey): IRequest<ResultViewModel>;

}
