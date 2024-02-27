using  Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicantValidPhotoInfo;

namespace Handler.ApplicantValidPhotoInfo
{
	public class GetAllApplicantValidPhotoInfoHandler : IRequestHandler<GetAllApplicantValidPhotoInfo, IQueryable<Rms.Models.ApplicantValidPhotoInfo>>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public GetAllApplicantValidPhotoInfoHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantValidPhotoInfo>> Handle(GetAllApplicantValidPhotoInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
