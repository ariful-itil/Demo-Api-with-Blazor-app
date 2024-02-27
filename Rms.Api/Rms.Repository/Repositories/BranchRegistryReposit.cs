
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class BranchRegistryReposit: RepositoryBase<BranchRegistry>, IBranchRegistry
	{
		public BranchRegistryReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
