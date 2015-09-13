using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Escowt.Data.Common;
using Escowt.Domain.Authorization;

namespace Escowt.Data.Authorization
{
	class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>, IEntityConfiguration
	{
		public UserGroupConfiguration()
		{
			ToTable("UserGroups", "Authorization");
			Property(ug => ug.Name).HasMaxLength(50);
		}

		public void AddConfiguration(ConfigurationRegistrar registrar)
		{
			registrar.Add(this);
		}
	}
}
