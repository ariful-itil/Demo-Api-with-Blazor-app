using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.FeesInfo;

namespace Handler.FeesInfo
{
	public class InsertFeesInfoHandler : IRequestHandler<InsertFeesInfo, ResultViewModel>
	{
		private readonly IFeesInfo ifeesinfo;
		public InsertFeesInfoHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<ResultViewModel> Handle(InsertFeesInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
