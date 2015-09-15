using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Escowt.Data.Common;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Globalization
{
	class LanguageConfiguration : BaseEntityTypeConfiguration<Language>
	{
		public LanguageConfiguration()
		{
			ToTable("Languages", "Globalization");
			Property(l => l.Alias).HasMaxLength(10).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LanguageAliasUnique", 1) { IsUnique = true }));
			Property(l => l.TitleRu).HasMaxLength(50);
			Property(l => l.TitleEn).HasMaxLength(50);
			Property(l => l.Description).HasMaxLength(1024);
			
		}
	}
}
