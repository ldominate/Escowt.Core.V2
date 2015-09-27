using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Escowt.Domain.Common;
using Escowt.Domain.Common.Interfaces;

namespace Escowt.Data.Common.Providers
{
	/// <summary>Базовый провайдер основных методов обработки</summary>
	/// <typeparam name="TModel"></typeparam>
	public abstract class BaseCRUDProvider<TModel> : IBaseCRUDProvider<TModel>
		where TModel : BaseDomainObject
	{
		protected readonly EscowtDB ContextDB;

		protected BaseCRUDProvider(EscowtDB contextDB)
		{
			ContextDB = contextDB;
		}

		public abstract TModel Insert(TModel model);

		protected TModel Insert(TModel model, params Expression<Func<TModel, object>>[] propertyNotChanges)
		{
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				var entry = ContextDB.Entry(model);

				entry.State = EntityState.Added;

				if (propertyNotChanges != null)
				{
					foreach (var propertyNotChange in propertyNotChanges)
					{
						entry.Property(propertyNotChange).IsModified = false;
					}
				}
				ContextDB.ChangeTracker.DetectChanges();

				ContextDB.SaveChanges();

				entry.State = EntityState.Detached;

				transaction.Commit();
			}
			return model;
		}

		public abstract TModel Update(TModel model);

		protected TModel Update(TModel model, params Expression<Func<TModel, object>>[] propertyNotChanges)
		{
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				var entry = ContextDB.Entry(model);

				entry.State = EntityState.Modified;

				if (propertyNotChanges != null)
				{
					foreach (var propertyNotChange in propertyNotChanges)
					{
						entry.Property(propertyNotChange).IsModified = false;
					}
				}
				ContextDB.ChangeTracker.DetectChanges();

				ContextDB.SaveChanges();

				entry.State = EntityState.Detached;

				transaction.Commit();
			}
			return model;
		}

		public bool Delete(Guid modelGuid)
		{
			bool result;

			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				var model = ContextDB.Set<TModel>().AsNoTracking().FirstOrDefault(m => m.Guid == modelGuid);

				if (model == null)
				{
					return false;
				}
				var entry = ContextDB.Entry(model);

				entry.State = EntityState.Deleted;

				ContextDB.ChangeTracker.DetectChanges();

				result = ContextDB.SaveChanges() > 0;

				entry.State = EntityState.Detached;

				transaction.Commit();
			}
			return result;
		}

		public virtual TModel GetById(Guid modelGuid)
		{
			TModel model;
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				model = ContextDB.Set<TModel>().AsNoTracking().FirstOrDefault(m => m.Guid == modelGuid);

				transaction.Commit();
			}
			return model;
		}

		public IQueryable<TModel> CollectionModels
		{
			get { return ContextDB.Set<TModel>(); }
		}

	}
}
