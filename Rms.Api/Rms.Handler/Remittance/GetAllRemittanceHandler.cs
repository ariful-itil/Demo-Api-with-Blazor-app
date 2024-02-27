using  Rms.Models;
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
	public class GetAllRemittanceHandler : IRequestHandler<GetAllRemittance, IQueryable<Rms.Models.Remittance>>
	{
		private readonly IRemittance iremittance;
		public GetAllRemittanceHandler(IRemittance _iremittance)
		{
			iremittance = _iremittance;
		}
		public async Task<IQueryable<Rms.Models.Remittance>> Handle(GetAllRemittance request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iremittance.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
