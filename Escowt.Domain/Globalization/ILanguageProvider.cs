using System.Linq;

namespace Escowt.Domain.Globalization
{
	public interface ILanguageProvider
	{
		Language Insert(Language language);

		Language Update(Language language);

		IQueryable<Language> Languages { get; }
	}
}
