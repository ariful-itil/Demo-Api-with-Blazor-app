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
	public class UpdateApplicantInfoHandler : IRequestHandler<UpdateApplicantInfo, ResultViewModel>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public UpdateApplicantInfoHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<ResultViewModel> Handle(UpdateApplicantInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
