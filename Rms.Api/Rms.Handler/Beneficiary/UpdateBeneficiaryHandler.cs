using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.Beneficiary;

namespace Handler.Beneficiary
{
	public class UpdateBeneficiaryHandler : IRequestHandler<UpdateBeneficiary, ResultViewModel>
	{
		private readonly IBeneficiary ibeneficiary;
		public UpdateBeneficiaryHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<ResultViewModel> Handle(UpdateBeneficiary request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
