using Escowt.Data.Common;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	class UserGroupCaptionConfiguration : BaseEntityTypeConfiguration<UserGroupCaption>
	{
		public UserGroupCaptionConfiguration()
		{
			ToTable("UserGroupCaptions", "Authorization");
			Property(ugc => ugc.UserGroupGuid).HasColumnOrder(0);
			Property(ugc => ugc.LanguageGuid).HasColumnOrder(1);
			Property(ugc => ugc.Title).HasMaxLength(255).IsRequired();
			Property(ugc => ugc.Description).HasMaxLength(1024).IsOptional();
			HasRequired(ugc => ugc.Language).WithMany().HasForeignKey(ugc => ugc.LanguageGuid).WillCascadeOnDelete(true);
			//HasOptional()
		}
	}
}
