using  Rms.Models;
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
	public class GetAllComputersHandler : IRequestHandler<GetAllComputers, IQueryable<Rms.Models.Computers>>
	{
		private readonly IComputers icomputers;
		public GetAllComputersHandler(IComputers _icomputers)
		{
			icomputers = _icomputers;
		}
		public async Task<IQueryable<Rms.Models.Computers>> Handle(GetAllComputers request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icomputers.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
