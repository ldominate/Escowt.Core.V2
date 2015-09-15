using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using Escowt.Data.Authorization;
using Escowt.Domain.Authorization;
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

		[TestMethod]
		public void SetNewUserGroupTest()
		{
			var userGroup = new UserGroup
			{
				Name = "MegaAdmin",
				Titles = new List<UserGroupCaption>
				{
					new UserGroupCaption
					{
						Title = "Контроль системы",
						Description = "Пользователи с наивысшими правами на все функциональные возможности системы (требуется для тестирования и отладки, права выделяются временно на период проведения тестов системы).",
						Language = _contextDB.Languages.FirstOrDefault(l => l.Alias == "ru")
					},
					new UserGroupCaption
					{
						Title = "Control system",
						Description = "Members with the highest rights to all the functionality of the system (required for testing and debugging, the rights allocated temporarily for the period of testing the system).",
						Language = _contextDB.Languages.FirstOrDefault(l => l.Alias == "en")
					}
				}
			};
			_provider.Insert(userGroup);

			var userGroupInserted = _provider.UserGroups.FirstOrDefault(u => u.Name == userGroup.Name);

			Assert.IsNotNull(userGroupInserted);
			Assert.AreEqual(userGroup.Name, userGroupInserted.Name);
		}

		[TestMethod]
		public void GetUserGroups()
		{
			var userGroups = _provider.UserGroups.ToList();

			Assert.IsNotNull(userGroups);
			Assert.IsTrue(userGroups.Any());
		}
	}
}
