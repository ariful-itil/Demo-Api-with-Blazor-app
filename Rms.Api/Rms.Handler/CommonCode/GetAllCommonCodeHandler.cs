using  Rms.Models;
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
	public class GetAllCommonCodeHandler : IRequestHandler<GetAllCommonCode, IQueryable<Rms.Models.CommonCode>>
	{
		private readonly ICommonCode icommoncode;
		public GetAllCommonCodeHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<IQueryable<Rms.Models.CommonCode>> Handle(GetAllCommonCode request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
