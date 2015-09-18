using System.Configuration;
using Autofac;
using Escowt.Data.Tests.Common.IoConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Escowt.Data.Tests.Common
{
	public abstract class BaseTest
	{
		protected IContainer ContainerIoC { get; private set; }

		protected EscowtDB ContextDB { get { return ContainerIoC.Resolve<EscowtDB>(); } }

		protected TProvider InstanceProvider<TProvider>()
		{
			Assert.IsTrue(ContainerIoC.IsRegistered<TProvider>());

			return ContainerIoC.Resolve<TProvider>();
		}
		
		[TestInitialize]
		public void TestInitialization()
		{
			var iocBuilder = new ContainerBuilder();

			iocBuilder.Register(c => new EscowtDB(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString())).SingleInstance();

			iocBuilder.RegisterModule(new ProviderModule());

			ContainerIoC = iocBuilder.Build();
		}

		[TestCleanup]
		public void TestCleanup()
		{
			ContainerIoC.Resolve<EscowtDB>().Dispose();

			ContainerIoC.Dispose();
		}
	}
}
