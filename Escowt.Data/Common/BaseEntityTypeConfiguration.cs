using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Escowt.Data.Common
{
	abstract class BaseEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity>, IEntityConfiguration
		where TEntity : class
	{
		public void AddConfiguration(ConfigurationRegistrar registrar)
		{
			registrar.Add(this);
		}
	}
}
