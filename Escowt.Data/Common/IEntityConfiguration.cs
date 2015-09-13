using System.Data.Entity.ModelConfiguration.Configuration;

namespace Escowt.Data.Common
{
	public interface IEntityConfiguration
	{
		void AddConfiguration(ConfigurationRegistrar registrar);
	}
}