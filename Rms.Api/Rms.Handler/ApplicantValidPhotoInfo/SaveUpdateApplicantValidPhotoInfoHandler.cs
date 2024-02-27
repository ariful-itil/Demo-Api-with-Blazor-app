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
	public class SaveUpdateApplicantValidPhotoInfoHandler : IRequestHandler<SaveUpdateApplicantValidPhotoInfo, ResultViewModel>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public SaveUpdateApplicantValidPhotoInfoHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<ResultViewModel> Handle(SaveUpdateApplicantValidPhotoInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.SaveUpdateAsync(request.expression,request.Model);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
