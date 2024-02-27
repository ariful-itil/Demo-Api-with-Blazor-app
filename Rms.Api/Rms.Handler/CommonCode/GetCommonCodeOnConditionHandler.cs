using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.CommonCode;

namespace Handler.CommonCode
{
	public class GetCommonCodeOnConditionHandler : IRequestHandler<GetCommonCodeOnCondition, IQueryable<Rms.Models.CommonCode>>
	{
		private readonly ICommonCode icommoncode;
		public GetCommonCodeOnConditionHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<IQueryable<Rms.Models.CommonCode>> Handle(GetCommonCodeOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
