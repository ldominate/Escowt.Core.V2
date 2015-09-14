using System.Linq;

namespace Escowt.Domain.Authorization
{
	public interface IUserGroupProvider
	{
		UserGroup SetUserGroup(UserGroup userGroup);

		IQueryable<UserGroup> UserGroups { get; }
	}
}
