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
	public class DeleteApplicantInfoHandler : IRequestHandler<DeleteApplicantInfo, ResultViewModel>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public DeleteApplicantInfoHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<ResultViewModel> Handle(DeleteApplicantInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.DeleteAsync(x=> x.SerialNo == request.SerialNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
