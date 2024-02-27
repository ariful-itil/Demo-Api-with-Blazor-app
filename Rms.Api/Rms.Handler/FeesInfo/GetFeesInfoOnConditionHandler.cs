using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.FeesInfo;

namespace Handler.FeesInfo
{
	public class GetFeesInfoOnConditionHandler : IRequestHandler<GetFeesInfoOnCondition, IQueryable<Rms.Models.FeesInfo>>
	{
		private readonly IFeesInfo ifeesinfo;
		public GetFeesInfoOnConditionHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<IQueryable<Rms.Models.FeesInfo>> Handle(GetFeesInfoOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
