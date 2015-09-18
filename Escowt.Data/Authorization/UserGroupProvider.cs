using Escowt.Data.Common.Providers;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	public class UserGroupProvider : BaseCRUDProvider<UserGroup>, IUserGroupProvider
	{
		public UserGroupProvider(EscowtDB contextDB) : base(contextDB)
		{

		}

	}
}
