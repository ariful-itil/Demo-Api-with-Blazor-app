using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.CommonCode;

namespace Handler.CommonCode
{
	public class GetCommonCodeOnKeysHandler : IRequestHandler<GetCommonCodeOnKeys, IQueryable<Rms.Models.CommonCode>>
	{
		private readonly ICommonCode icommoncode;
		public GetCommonCodeOnKeysHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<IQueryable<Rms.Models.CommonCode>> Handle(GetCommonCodeOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.FindByConditionAsync(x=> x.BankCode == request.BankCode & x.Code == request.Code);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
