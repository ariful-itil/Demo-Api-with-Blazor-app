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
	public class SaveUpdateBeneficiaryHandler : IRequestHandler<SaveUpdateBeneficiary, ResultViewModel>
	{
		private readonly IBeneficiary ibeneficiary;
		public SaveUpdateBeneficiaryHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateBeneficiary request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
