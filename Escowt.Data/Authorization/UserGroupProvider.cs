using System;
using System.Data.Entity;
using System.Linq;
using Escowt.Data.Common.Providers;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	public class UserGroupProvider : BaseCRUDProvider<UserGroup>, IUserGroupProvider
	{
		public UserGroupProvider(EscowtDB contextDB) : base(contextDB)
		{

		}

		public override UserGroup GetById(Guid modelGuid)
		{
			var userGroup = ContextDB.Set<UserGroup>().Where(m => m.Guid == modelGuid).Include(ug => ug.Titles).FirstOrDefault();

			return userGroup;
		}
	}
}
