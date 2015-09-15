using System.Data.Entity;
using System.Diagnostics;
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

		public Language Insert(Language language)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				_contextDB.Entry(language).State = EntityState.Added;

				_contextDB.SaveChanges();
				transaction.Commit();
			}
			return language;
		}

		public Language Update(Language language)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				_contextDB.Entry(language).State = EntityState.Modified;
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
