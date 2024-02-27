using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Computers;

namespace Handler.Computers
{
	public class GetComputersOnConditionHandler : IRequestHandler<GetComputersOnCondition, IQueryable<Rms.Models.Computers>>
	{
		private readonly IComputers icomputers;
		public GetComputersOnConditionHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<IQueryable<Rms.Models.Computers>> Handle(GetComputersOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
