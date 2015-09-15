using System.Linq;

namespace Escowt.Domain.Authorization
{
	public interface IUserGroupProvider
	{
		UserGroup Insert(UserGroup userGroup);

		IQueryable<UserGroup> UserGroups { get; }
	}
}
