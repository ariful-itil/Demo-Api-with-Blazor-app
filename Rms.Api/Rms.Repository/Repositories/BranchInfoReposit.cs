
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class BranchInfoReposit: RepositoryBase<BranchInfo>, IBranchInfo
	{
		public BranchInfoReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
