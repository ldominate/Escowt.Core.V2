using Autofac;
using Escowt.Data.Authorization;
using Escowt.Data.Globalization;
using Escowt.Domain.Authorization;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Tests.Common.IoConfiguration
{
	public class ProviderModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<LanguageProvider>().As<ILanguageProvider>();

			builder.RegisterType<UserGroupProvider>().As<IUserGroupProvider>();
		}
	}
}
