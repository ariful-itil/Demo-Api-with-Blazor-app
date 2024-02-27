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
	public class DeleteApplicantValidPhotoInfoHandler : IRequestHandler<DeleteApplicantValidPhotoInfo, ResultViewModel>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public DeleteApplicantValidPhotoInfoHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<ResultViewModel> Handle(DeleteApplicantValidPhotoInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.DeleteAsync(x=> x.SlNumber == request.SlNumber);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
