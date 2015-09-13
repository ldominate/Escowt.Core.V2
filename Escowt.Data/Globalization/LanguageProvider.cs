using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
				if (_contextDB.Languages.Find(language.Guid) == null)
				{
					
				}
			}
			return language;
		}

		public IQueryable<Language> Languages
		{
			get { return _contextDB.Languages; }
		}
	}
}
