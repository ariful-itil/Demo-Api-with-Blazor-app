using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Remittance;

namespace Handler.Remittance
{
	public class DeleteRemittanceHandler : IRequestHandler<DeleteRemittance, ResultViewModel>
	{
		private readonly IRemittance iremittance;
		public DeleteRemittanceHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<ResultViewModel> Handle(DeleteRemittance request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.DeleteAsync(x=> x.IdentityNo == request.IdentityNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
