
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class BeneficiaryReposit: RepositoryBase<Beneficiary>, IBeneficiary
	{
		public BeneficiaryReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
