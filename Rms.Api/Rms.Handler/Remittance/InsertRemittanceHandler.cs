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
	public class InsertRemittanceHandler : IRequestHandler<InsertRemittance, ResultViewModel>
	{
		private readonly IRemittance iremittance;
		public InsertRemittanceHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<ResultViewModel> Handle(InsertRemittance request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
