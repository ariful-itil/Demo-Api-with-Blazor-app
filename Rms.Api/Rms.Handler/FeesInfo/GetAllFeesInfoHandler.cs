using  Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.FeesInfo;

namespace Handler.FeesInfo
{
	public class GetAllFeesInfoHandler : IRequestHandler<GetAllFeesInfo, IQueryable<Rms.Models.FeesInfo>>
	{
		private readonly IFeesInfo ifeesinfo;
		public GetAllFeesInfoHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<IQueryable<Rms.Models.FeesInfo>> Handle(GetAllFeesInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
