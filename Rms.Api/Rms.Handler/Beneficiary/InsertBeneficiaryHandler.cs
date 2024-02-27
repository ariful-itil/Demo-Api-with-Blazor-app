using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Beneficiary;

namespace Handler.Beneficiary
{
	public class InsertBeneficiaryHandler : IRequestHandler<InsertBeneficiary, ResultViewModel>
	{
		private readonly IBeneficiary ibeneficiary;
		public InsertBeneficiaryHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<ResultViewModel> Handle(InsertBeneficiary request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
