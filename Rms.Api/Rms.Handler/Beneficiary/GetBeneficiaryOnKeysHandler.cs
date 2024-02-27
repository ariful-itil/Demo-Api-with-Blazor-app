using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Beneficiary;

namespace Handler.Beneficiary
{
	public class GetBeneficiaryOnKeysHandler : IRequestHandler<GetBeneficiaryOnKeys, IQueryable<Rms.Models.Beneficiary>>
	{
		private readonly IBeneficiary ibeneficiary;
		public GetBeneficiaryOnKeysHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<IQueryable<Rms.Models.Beneficiary>> Handle(GetBeneficiaryOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.FindByConditionAsync(x=> x.BranchCode == request.BranchCode & x.AGEXIDNO == request.AGEXIDNO & x.SerialNo == request.SerialNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
