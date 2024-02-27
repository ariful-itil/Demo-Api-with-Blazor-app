using Rms.Models;
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
	public class GetApplicantValidPhotoInfoOnKeysHandler : IRequestHandler<GetApplicantValidPhotoInfoOnKeys, IQueryable<Rms.Models.ApplicantValidPhotoInfo>>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public GetApplicantValidPhotoInfoOnKeysHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantValidPhotoInfo>> Handle(GetApplicantValidPhotoInfoOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.FindByConditionAsync(x=> x.SlNumber == request.SlNumber);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
