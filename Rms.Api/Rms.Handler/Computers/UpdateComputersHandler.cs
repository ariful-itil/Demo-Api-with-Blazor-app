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
	public class UpdateComputersHandler : IRequestHandler<UpdateComputers, ResultViewModel>
	{
		private readonly IComputers icomputers;
		public UpdateComputersHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<ResultViewModel> Handle(UpdateComputers request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
