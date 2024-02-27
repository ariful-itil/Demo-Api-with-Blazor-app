
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class RemittanceReposit: RepositoryBase<Remittance>, IRemittance
	{
		public RemittanceReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
