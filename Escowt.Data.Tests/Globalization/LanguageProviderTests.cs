using System.Linq;
using Escowt.Data.Tests.Common;
using Escowt.Domain.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Escowt.Data.Tests.Globalization
{
	[TestClass]
	public class LanguageProviderTests : BaseTest
	{
		private ILanguageProvider _provider;

		[TestInitialize]
		public void TestInitialize()
		{
			_provider = InstanceProvider<ILanguageProvider>();
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

			var langDB = _provider.CollectionModels.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}

		[TestMethod]
		public void ChangeEsLanguageTest()
		{
			var language = _provider.CollectionModels.FirstOrDefault(l => l.Alias == "es-ES");

			Assert.IsNotNull(language);

			language.Description = "Это испания2!!!";

			_provider.Update(language);

			var languageChange = _provider.CollectionModels.FirstOrDefault(l => l.Alias == "es-ES");

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

			var langDB = _provider.CollectionModels.FirstOrDefault(l => l.Guid == lguid);

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

			var langDB = _provider.CollectionModels.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}

	}
}
