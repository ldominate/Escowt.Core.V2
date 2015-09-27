using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Escowt.Data.Common;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	class UserGroupConfiguration : BaseEntityTypeConfiguration<UserGroup>
	{
		public UserGroupConfiguration()
		{
			ToTable("UserGroups", "Authorization");
			Property(ug => ug.Name).HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_UserGroupsNameUnique", 1) { IsUnique = true }));
			HasMany(ug => ug.Titles).WithOptional().HasForeignKey(ugc => ugc.UserGroupGuid).WillCascadeOnDelete(true);
		}
	}
}
