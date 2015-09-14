using Escowt.Data.Common;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	class UserGroupConfiguration : BaseEntityTypeConfiguration<UserGroup>
	{
		public UserGroupConfiguration()
		{
			ToTable("UserGroups", "Authorization");
			Property(ug => ug.Name).HasMaxLength(50);
			HasMany(ug => ug.Titles).WithOptional().HasForeignKey(ugc => ugc.UserGroupGuid);
		}
	}
}
