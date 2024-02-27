
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class ApplicantInfoReposit: RepositoryBase<ApplicantInfo>, IApplicantInfo
	{
		public ApplicantInfoReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
