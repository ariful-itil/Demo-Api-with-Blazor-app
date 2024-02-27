using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicantValidPhotoInfo;

namespace Handler.ApplicantValidPhotoInfo
{
	public class GetApplicantValidPhotoInfoOnConditionHandler : IRequestHandler<GetApplicantValidPhotoInfoOnCondition, IQueryable<Rms.Models.ApplicantValidPhotoInfo>>
	{
		private readonly IApplicantValidPhotoInfo iapplicantvalidphotoinfo;
		public GetApplicantValidPhotoInfoOnConditionHandler(IApplicantValidPhotoInfo _iapplicantvalidphotoinfo)
		{
			iapplicantvalidphotoinfo = _iapplicantvalidphotoinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantValidPhotoInfo>> Handle(GetApplicantValidPhotoInfoOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantvalidphotoinfo.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
