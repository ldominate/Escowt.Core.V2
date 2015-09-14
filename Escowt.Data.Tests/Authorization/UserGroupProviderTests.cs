using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Escowt.Data.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Escowt.Data.Tests.Authorization
{
	[TestClass]
	public class UserGroupProviderTests
	{
		private EscowtDB _contextDB;
		private UserGroupProvider _provider;

		[TestInitialize]
		public void TestInitialize()
		{
			var connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

			_contextDB = new EscowtDB(connectionStrings);

			_contextDB.Database.Initialize(false);

			_provider = new UserGroupProvider(_contextDB);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_contextDB.Dispose();
		}

		public void SetNewUserGroupTest()
		{
			
		}
	}
}
