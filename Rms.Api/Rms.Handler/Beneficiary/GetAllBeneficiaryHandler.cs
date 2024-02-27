using  Rms.Models;
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
	public class GetAllBeneficiaryHandler : IRequestHandler<GetAllBeneficiary, IQueryable<Rms.Models.Beneficiary>>
	{
		private readonly IBeneficiary ibeneficiary;
		public GetAllBeneficiaryHandler(IBeneficiary _ibeneficiary)
		{
			ibeneficiary = _ibeneficiary;
		}
		public async Task<IQueryable<Rms.Models.Beneficiary>> Handle(GetAllBeneficiary request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ibeneficiary.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
