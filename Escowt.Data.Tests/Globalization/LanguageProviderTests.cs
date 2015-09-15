using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Escowt.Data.Globalization;
using Escowt.Domain.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Escowt.Data.Tests.Globalization
{
	[TestClass]
	public class LanguageProviderTests
	{
		private EscowtDB _contextDB;
		private LanguageProvider _provider;

		[TestInitialize]
		public void TestInitialize()
		{
			var connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EscowtDB>());

			_contextDB = new EscowtDB(connectionStrings);

			_contextDB.Database.Initialize(false);

			_provider = new LanguageProvider(_contextDB);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_contextDB.Dispose();
		}

		[TestMethod]
		public void SetEsLanguageTest()
		{
			var lang = new Language
			{
				Alias = "es-ES",
				TitleRu = "Испанский (Испания)",
				TitleEn = "Spanish (Spain)",
				Description = "Это испания!!!"
			};

			var lguid = lang.Guid;

			_provider.Insert(lang);

			var langDB = _provider.Languages.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}

		[TestMethod]
		public void ChangeEsLanguageTest()
		{
			var language = _provider.Languages.FirstOrDefault(l => l.Alias == "es-ES");

			Assert.IsNotNull(language);

			language.Description = "Это испания2!!!";

			_provider.Update(language);

			var languageChange = _provider.Languages.FirstOrDefault(l => l.Alias == "es-ES");

			Assert.IsNotNull(languageChange);

			Assert.AreEqual(language.Description, languageChange.Description);
		}

		[TestMethod]
		public void SetRuLanguageTest()
		{
			var lang = new Language
			{
				Alias = "ru",
				TitleRu = "Русский",
				TitleEn = "Russian",
				Description = "Русский"
			};

			var lguid = lang.Guid;

			_provider.Insert(lang);

			var langDB = _provider.Languages.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}

		[TestMethod]
		public void SetEnLanguageTest()
		{
			var lang = new Language
			{
				Alias = "en",
				TitleRu = "Английский",
				TitleEn = "English",
				Description = "English (UK)"
			};

			var lguid = lang.Guid;

			_provider.Insert(lang);

			var langDB = _provider.Languages.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}

	}
}
