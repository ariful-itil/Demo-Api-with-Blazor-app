
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class ExchangeRateInfoReposit: RepositoryBase<ExchangeRateInfo>, IExchangeRateInfo
	{
		public ExchangeRateInfoReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
