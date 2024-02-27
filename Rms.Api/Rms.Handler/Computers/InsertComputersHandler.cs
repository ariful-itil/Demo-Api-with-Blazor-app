using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Computers;

namespace Handler.Computers
{
	public class InsertComputersHandler : IRequestHandler<InsertComputers, ResultViewModel>
	{
		private readonly IComputers icomputers;
		public InsertComputersHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<ResultViewModel> Handle(InsertComputers request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
