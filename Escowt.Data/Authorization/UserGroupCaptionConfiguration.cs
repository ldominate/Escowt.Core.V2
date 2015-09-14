using Escowt.Data.Common;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	class UserGroupCaptionConfiguration : BaseEntityTypeConfiguration<UserGroupCaption>
	{
		public UserGroupCaptionConfiguration()
		{
			ToTable("UserGroupCaptions", "Authorization");
			Property(ugc => ugc.Title).HasMaxLength(255).IsRequired();
			Property(ugc => ugc.Description).HasMaxLength(1024).IsOptional();
			HasRequired(ugc => ugc.Language).WithRequiredPrincipal().Map(ugc => ugc.MapKey("LanguageGuid"));
		}
	}
}
