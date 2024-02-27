using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.FeesInfo;

namespace Handler.FeesInfo
{
	public class UpdateFeesInfoHandler : IRequestHandler<UpdateFeesInfo, ResultViewModel>
	{
		private readonly IFeesInfo ifeesinfo;
		public UpdateFeesInfoHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<ResultViewModel> Handle(UpdateFeesInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
