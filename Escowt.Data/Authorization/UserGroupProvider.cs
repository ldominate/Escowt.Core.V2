using System.Data.Entity;
using System.Diagnostics;
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

		public UserGroup Insert(UserGroup userGroup)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				_contextDB.Entry(userGroup).State = EntityState.Added;

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
