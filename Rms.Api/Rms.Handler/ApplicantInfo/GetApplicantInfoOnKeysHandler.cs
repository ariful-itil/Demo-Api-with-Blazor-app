using Rms.Models;
using System;
using MediatR;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using ViewModels;
using Queries.ApplicantInfo;

namespace Handler.ApplicantInfo
{
	public class GetApplicantInfoOnKeysHandler : IRequestHandler<GetApplicantInfoOnKeys, IQueryable<Rms.Models.ApplicantInfo>>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public GetApplicantInfoOnKeysHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantInfo>> Handle(GetApplicantInfoOnKeys request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.FindByConditionAsync(x=> x.SerialNo == request.SerialNo);
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
