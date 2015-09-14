using System.Linq;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	public class UserGroupProvider : IUserGroupProvider
	{
		private readonly EscowtDB _contextDB;

		public UserGroupProvider(EscowtDB contextDB)
		{
			_contextDB = contextDB;
		}

		public UserGroup SetUserGroup(UserGroup userGroup)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.UserGroups.Add(userGroup);

				_contextDB.SaveChanges();

				transaction.Commit();
			}
			return userGroup;
		}

		public IQueryable<UserGroup> UserGroups
		{
			get { return _contextDB.UserGroups; }
		}
	}
}
