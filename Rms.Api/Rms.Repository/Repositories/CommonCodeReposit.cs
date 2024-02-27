
using Interfaces;
using Rms.Models;
using Repository;

namespace Repositories
{
	public class CommonCodeReposit: RepositoryBase<CommonCode>, ICommonCode
	{
		public CommonCodeReposit(IServiceProvider provider):base(provider)
		{
		}
	}
}
