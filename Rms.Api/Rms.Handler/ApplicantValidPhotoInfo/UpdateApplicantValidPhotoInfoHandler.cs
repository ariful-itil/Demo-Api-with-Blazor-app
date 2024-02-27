using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Commands.ApplicantValidPhotoInfo;

namespace Handler.ApplicantValidPhotoInfo
{
	public class UpdateApplicantValidPhotoInfoHandler : IRequestHandler<UpdateApplicantValidPhotoInfo, ResultViewModel>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public UpdateApplicantValidPhotoInfoHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<ResultViewModel> Handle(UpdateApplicantValidPhotoInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.UpdateAsync(request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
