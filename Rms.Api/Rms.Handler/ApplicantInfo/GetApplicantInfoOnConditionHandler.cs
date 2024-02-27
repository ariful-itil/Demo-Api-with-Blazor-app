using Rms.Models;
using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicantInfo;

namespace Handler.ApplicantInfo
{
	public class GetApplicantInfoOnConditionHandler : IRequestHandler<GetApplicantInfoOnCondition, IQueryable<Rms.Models.ApplicantInfo>>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public GetApplicantInfoOnConditionHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantInfo>> Handle(GetApplicantInfoOnCondition request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.FindByConditionAsync(request.expression);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
