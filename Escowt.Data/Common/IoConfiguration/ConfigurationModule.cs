using Autofac;
using Escowt.Data.Authorization;
using Escowt.Data.Globalization;

namespace Escowt.Data.Common.IoConfiguration
{
	public class ConfigurationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<LanguageConfiguration>().As<IEntityConfiguration>();
			builder.RegisterType<UserGroupConfiguration>().As<IEntityConfiguration>();
			builder.RegisterType<UserGroupCaptionConfiguration>().As<IEntityConfiguration>();
		}
	}
}
