using  Rms.Models;
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
	public class GetAllApplicantInfoHandler : IRequestHandler<GetAllApplicantInfo, IQueryable<Rms.Models.ApplicantInfo>>
	{
		private readonly IApplicantInfo iapplicantinfo;
		public GetAllApplicantInfoHandler(IApplicantInfo _iapplicantinfo)
		{
			iapplicantinfo = _iapplicantinfo;
		}
		public async Task<IQueryable<Rms.Models.ApplicantInfo>> Handle(GetAllApplicantInfo request, CancellationToken cancellationToken)
		{
			try
			{
				var data = await iapplicantinfo.FindAllAsync();
				return data;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

}
