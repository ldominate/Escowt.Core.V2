using System.Linq;

namespace Escowt.Domain.Globalization
{
	public interface ILanguageProvider
	{
		Language SetLanguage(Language language);

		IQueryable<Language> Languages { get; }
	}
}
