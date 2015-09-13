using System;
using System.Collections.Generic;
using System.Configuration;
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
		public void SetNewLanguageTest()
		{
			var lang = new Language
			{
				Alias = "es-ES",
				TitleRu = "Испанский (Испания)",
				TitleEn = "Spanish (Spain)",
				Description = "Это испания!!!"
			};

			var lguid = lang.Guid;

			_provider.SetLanguage(lang);

			var langDB = _provider.Languages.FirstOrDefault(l => l.Guid == lguid);

			Assert.IsNotNull(langDB);
			Assert.AreEqual(langDB.Guid, lang.Guid);
		}


	}
}
