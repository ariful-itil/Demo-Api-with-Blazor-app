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
	public class UpdateCommonCodeHandler : IRequestHandler<UpdateCommonCode, ResultViewModel>
	{
		private readonly ICommonCode icommoncode;
		public UpdateCommonCodeHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<ResultViewModel> Handle(UpdateCommonCode request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
