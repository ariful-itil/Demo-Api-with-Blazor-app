
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class ComputersReposit: RepositoryBase<Computers>, IComputers
	{
		public ComputersReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
