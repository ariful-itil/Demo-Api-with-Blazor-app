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
	public class DeleteCommonCodeHandler : IRequestHandler<DeleteCommonCode, ResultViewModel>
	{
		private readonly ICommonCode icommoncode;
		public DeleteCommonCodeHandler(ICommonCode _icommoncode)
		{
			icommoncode = _icommoncode;
		}
		public async Task<ResultViewModel> Handle(DeleteCommonCode request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await icommoncode.DeleteAsync(x=> x.BankCode == request.BankCode & x.Code == request.Code);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
