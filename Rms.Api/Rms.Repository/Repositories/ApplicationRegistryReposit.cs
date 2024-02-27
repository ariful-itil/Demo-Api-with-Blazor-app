
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class ApplicationRegistryReposit: RepositoryBase<ApplicationRegistry>, IApplicationRegistry
	{
		public ApplicationRegistryReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
