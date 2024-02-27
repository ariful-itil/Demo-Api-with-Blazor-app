using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.CommonCode;

namespace Handler.CommonCode
{
	public class InsertCommonCodeHandler : IRequestHandler<InsertCommonCode, ResultViewModel>
	{
		private readonly ICommonCode icommoncode;
		public InsertCommonCodeHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<ResultViewModel> Handle(InsertCommonCode request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
