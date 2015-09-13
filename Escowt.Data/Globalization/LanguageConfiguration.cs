using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Escowt.Data.Common;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Globalization
{
	class LanguageConfiguration : EntityTypeConfiguration<Language>, IEntityConfiguration
	{
		public LanguageConfiguration()
		{
			ToTable("[Languages]", "[Globalization]");
			Property(l => l.Alias).HasMaxLength(10);
			Property(l => l.TitleRu).HasMaxLength(50);
			Property(l => l.TitleEn).HasMaxLength(50);
			Property(l => l.Description).HasMaxLength(1024);
		}

		public void AddConfiguration(ConfigurationRegistrar registrar)
		{
			registrar.Add(this);
		}
	}
}
