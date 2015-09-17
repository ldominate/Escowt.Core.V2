using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Escowt.Domain.Common;
using Escowt.Domain.Common.Interfaces;

namespace Escowt.Data.Common.Providers
{
	public class BaseCRUDProvider<TModel> : IBaseCRUDProvider<TModel>
		where TModel : BaseDomainObject
	{
		private readonly EscowtDB _contextDB;

		protected BaseCRUDProvider(EscowtDB contextDB)
		{
			_contextDB = contextDB;
		}

		public TModel Insert(TModel model)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				_contextDB.Entry(model).State = EntityState.Added;

				_contextDB.SaveChanges();
				transaction.Commit();
			}
			return model;
		}

		public TModel Update(TModel model)
		{
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				_contextDB.Entry(model).State = EntityState.Modified;
				_contextDB.SaveChanges();

				transaction.Commit();
			}
			return model;
		}

		public bool Delete(Guid modelGuid)
		{
			bool result;

			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				var model = _contextDB.Set<TModel>().FirstOrDefault(m => m.Guid == modelGuid);

				if (model == null)
				{
					return false;
				}
				_contextDB.Entry(model).State = EntityState.Deleted;

				result = _contextDB.SaveChanges() > 0;

				transaction.Commit();
			}
			return result;
		}

		public TModel GetById(Guid modelGuid)
		{
			TModel model;
			using (var transaction = _contextDB.Database.BeginTransaction())
			{
				_contextDB.Database.Log = (s => Debug.WriteLine(s));

				model = _contextDB.Set<TModel>().FirstOrDefault(m => m.Guid == modelGuid);

				transaction.Commit();
			}
			return model;
		}

		public IQueryable<TModel> CollectionModels
		{
			get { return _contextDB.Set<TModel>(); }
		}
	}
}
