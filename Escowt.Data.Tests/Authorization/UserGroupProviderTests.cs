using System.Collections.Generic;
using System.Linq;
using Escowt.Data.Tests.Common;
using Escowt.Domain.Authorization;
using Escowt.Domain.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Escowt.Data.Tests.Authorization
{
	[TestClass]
	public class UserGroupProviderTests : BaseTest
	{
		private IUserGroupProvider _provider;

		[TestInitialize]
		public void TestInitialize()
		{
			_provider = InstanceProvider<IUserGroupProvider>();
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
						Language = InstanceProvider<ILanguageProvider>().CollectionModels.FirstOrDefault(l => l.Alias == "ru")
					},
					new UserGroupCaption
					{
						Title = "Control system",
						Description = "Members with the highest rights to all the functionality of the system (required for testing and debugging, the rights allocated temporarily for the period of testing the system).",
						Language = InstanceProvider<ILanguageProvider>().CollectionModels.FirstOrDefault(l => l.Alias == "en")
					}
				}
			};
			_provider.Insert(userGroup);

			var userGroupInserted = _provider.CollectionModels.FirstOrDefault(u => u.Name == userGroup.Name);

			Assert.IsNotNull(userGroupInserted);
			Assert.AreEqual(userGroup.Name, userGroupInserted.Name);
		}

		[TestMethod]
		public void GetUserGroups()
		{
			var userGroups = _provider.CollectionModels.ToList();

			Assert.IsNotNull(userGroups);
			Assert.IsTrue(userGroups.Any());
		}
	}
}
