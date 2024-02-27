using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicantInfo;

namespace Handler.ApplicantInfo
{
	public class SaveUpdateApplicantInfoHandler : IRequestHandler<SaveUpdateApplicantInfo, ResultViewModel>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public SaveUpdateApplicantInfoHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateApplicantInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
