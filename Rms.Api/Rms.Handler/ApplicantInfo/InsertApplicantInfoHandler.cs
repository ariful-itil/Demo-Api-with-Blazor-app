using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicantInfo;

namespace Handler.ApplicantInfo
{
	public class InsertApplicantInfoHandler : IRequestHandler<InsertApplicantInfo, ResultViewModel>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public InsertApplicantInfoHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<ResultViewModel> Handle(InsertApplicantInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
