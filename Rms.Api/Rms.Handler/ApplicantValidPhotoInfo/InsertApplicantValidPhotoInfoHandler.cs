using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicantValidPhotoInfo;

namespace Handler.ApplicantValidPhotoInfo
{
	public class InsertApplicantValidPhotoInfoHandler : IRequestHandler<InsertApplicantValidPhotoInfo, ResultViewModel>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public InsertApplicantValidPhotoInfoHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<ResultViewModel> Handle(InsertApplicantValidPhotoInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.SaveAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
