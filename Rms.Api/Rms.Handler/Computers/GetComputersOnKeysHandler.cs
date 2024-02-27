using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.Computers;

namespace Handler.Computers
{
	public class GetComputersOnKeysHandler : IRequestHandler<GetComputersOnKeys, IQueryable<Rms.Models.Computers>>
	{
		private readonly IComputers icomputers;
		public GetComputersOnKeysHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<IQueryable<Rms.Models.Computers>> Handle(GetComputersOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.FindByConditionAsync(x=> x.SLNo == request.SLNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
