using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Remittance;

namespace Handler.Remittance
{
	public class UpdateRemittanceHandler : IRequestHandler<UpdateRemittance, ResultViewModel>
	{
		private readonly IRemittance iremittance;
		public UpdateRemittanceHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<ResultViewModel> Handle(UpdateRemittance request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
