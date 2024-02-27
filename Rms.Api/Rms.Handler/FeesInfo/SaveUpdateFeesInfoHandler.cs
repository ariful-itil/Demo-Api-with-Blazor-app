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
	public class SaveUpdateFeesInfoHandler : IRequestHandler<SaveUpdateFeesInfo, ResultViewModel>
	{
		private readonly IFeesInfo ifeesinfo;
		public SaveUpdateFeesInfoHandler(IFeesInfo _ifeesinfo)
		{
			ifeesinfo = _ifeesinfo;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateFeesInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await ifeesinfo.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
