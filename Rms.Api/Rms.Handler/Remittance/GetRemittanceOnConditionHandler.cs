using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Remittance;

namespace Handler.Remittance
{
	public class GetRemittanceOnConditionHandler : IRequestHandler<GetRemittanceOnCondition, IQueryable<Rms.Models.Remittance>>
	{
		private readonly IRemittance iremittance;
		public GetRemittanceOnConditionHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<IQueryable<Rms.Models.Remittance>> Handle(GetRemittanceOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
