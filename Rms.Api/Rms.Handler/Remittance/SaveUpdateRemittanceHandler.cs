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
	public class SaveUpdateRemittanceHandler : IRequestHandler<SaveUpdateRemittance, ResultViewModel>
	{
		private readonly IRemittance iremittance;
		public SaveUpdateRemittanceHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateRemittance request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
