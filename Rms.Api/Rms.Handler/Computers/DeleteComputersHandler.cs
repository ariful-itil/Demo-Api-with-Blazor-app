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
	public class DeleteComputersHandler : IRequestHandler<DeleteComputers, ResultViewModel>
	{
		private readonly IComputers icomputers;
		public DeleteComputersHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<ResultViewModel> Handle(DeleteComputers request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.DeleteAsync(x=> x.SLNo == request.SLNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
