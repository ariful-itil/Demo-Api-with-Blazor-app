
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class FeesInfoReposit: RepositoryBase<FeesInfo>, IFeesInfo
	{
		public FeesInfoReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
