using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Computers;

namespace Handler.Computers
{
	public class SaveUpdateComputersHandler : IRequestHandler<SaveUpdateComputers, ResultViewModel>
	{
		private readonly IComputers icomputers;
		public SaveUpdateComputersHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateComputers request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
