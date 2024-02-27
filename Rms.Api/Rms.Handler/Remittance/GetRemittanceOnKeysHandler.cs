using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Remittance;

namespace Handler.Remittance
{
	public class GetRemittanceOnKeysHandler : IRequestHandler<GetRemittanceOnKeys, IQueryable<Rms.Models.Remittance>>
	{
		private readonly IRemittance iremittance;
		public GetRemittanceOnKeysHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<IQueryable<Rms.Models.Remittance>> Handle(GetRemittanceOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.FindByConditionAsync(x=> x.IdentityNo == request.IdentityNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
