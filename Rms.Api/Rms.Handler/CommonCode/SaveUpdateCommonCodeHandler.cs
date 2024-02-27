using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.CommonCode;

namespace Handler.CommonCode
{
	public class SaveUpdateCommonCodeHandler : IRequestHandler<SaveUpdateCommonCode, ResultViewModel>
	{
		private readonly ICommonCode icommoncode;
		public SaveUpdateCommonCodeHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateCommonCode request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
