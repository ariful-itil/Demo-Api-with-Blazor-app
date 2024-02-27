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
	public class DeleteBeneficiaryHandler : IRequestHandler<DeleteBeneficiary, ResultViewModel>
	{
		private readonly IBeneficiary ibeneficiary;
		public DeleteBeneficiaryHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<ResultViewModel> Handle(DeleteBeneficiary request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.DeleteAsync(x=> x.BranchCode == request.BranchCode & x.AGEXIDNO == request.AGEXIDNO & x.SerialNo == request.SerialNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
