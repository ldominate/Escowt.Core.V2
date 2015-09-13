using System.Linq;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Globalization
{
	public class LanguageProvider : ILanguageProvider
	{
		private readonly EscowtDB _contextDB;

		public LanguageProvider(EscowtDB contextDB)
		{
			_contextDB = contextDB;
		}

		public Language SetLanguage(Language language)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Languages.Add(language);

				_contextDB.SaveChanges();

				transaction.Commit();
			}
			return language;
		}

		public IQueryable<Language> Languages
		{
			get { return _contextDB.Languages; }
		}
	}
}
