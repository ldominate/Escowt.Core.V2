using System.Data.Entity;
using Escowt.Data.Authorization;
using Escowt.Data.Globalization;
using Escowt.Domain.Authorization;
using Escowt.Domain.Globalization;

namespace Escowt.Data
{

	public class EscowtDB : DbContext
	{
		// Контекст настроен для использования строки подключения "EscowtDB" из файла конфигурации  
		// приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
		// "Escowt.Data.EscowtDB" в экземпляре LocalDb. 
		// 
		// Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "EscowtDB" 
		// в файле конфигурации приложения.
		public EscowtDB()
			: base("name=ConnectionDB")
		{
			
		}
		
		public EscowtDB(string connection) : base(connection)
		{

		}

		// Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
		// о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Language> Languages { get; set; }

		public virtual DbSet<UserGroup> UserGroups { get; set; }

		public virtual DbSet<UserGroupCaption> UserGroupCaptions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new LanguageConfiguration());
			modelBuilder.Configurations.Add(new UserGroupConfiguration());
			modelBuilder.Configurations.Add(new UserGroupCaptionConfiguration());
			
			base.OnModelCreating(modelBuilder);
		}
	}
}