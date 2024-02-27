using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Beneficiary;

namespace Handler.Beneficiary
{
	public class GetBeneficiaryOnConditionHandler : IRequestHandler<GetBeneficiaryOnCondition, IQueryable<Rms.Models.Beneficiary>>
	{
		private readonly IBeneficiary ibeneficiary;
		public GetBeneficiaryOnConditionHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<IQueryable<Rms.Models.Beneficiary>> Handle(GetBeneficiaryOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
