
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class ApplicantValidPhotoInfoReposit: RepositoryBase<ApplicantValidPhotoInfo>, IApplicantValidPhotoInfo
	{
		public ApplicantValidPhotoInfoReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
