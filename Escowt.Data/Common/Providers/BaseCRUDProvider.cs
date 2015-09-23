using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
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

		public TModel Insert(TModel model)
		{
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				ContextDB.Entry(model).State = EntityState.Added;

				ContextDB.SaveChanges();
				transaction.Commit();
			}
			return model;
		}

		public virtual TModel Update(TModel model)
		{
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				ContextDB.Entry(model).State = EntityState.Modified;
				ContextDB.SaveChanges();

				transaction.Commit();
			}
			return model;
		}

		public virtual TModel Update(TModel model, IEnumerable<string> propertyNotChanges)
		{
			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				ContextDB.Entry(model).State = EntityState.Modified;

				foreach (var propertyNotChange in propertyNotChanges)
				{
					ContextDB.Entry(model).Property(propertyNotChange).IsModified = false;
				}

				ContextDB.SaveChanges();

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

				var model = ContextDB.Set<TModel>().FirstOrDefault(m => m.Guid == modelGuid);

				if (model == null)
				{
					return false;
				}
				ContextDB.Entry(model).State = EntityState.Deleted;

				result = ContextDB.SaveChanges() > 0;

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

				model = ContextDB.Set<TModel>().FirstOrDefault(m => m.Guid == modelGuid);

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
