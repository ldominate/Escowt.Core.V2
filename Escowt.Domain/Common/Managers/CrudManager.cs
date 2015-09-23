using System;
using System.Linq;
using Escowt.Data.Common.Managers;
using Escowt.Domain.Common.Interfaces;

namespace Escowt.Domain.Common.Managers
{
	public abstract class CrudManager<TModel> : BaseManager, ICrudManager<TModel> where TModel : BaseDomainObject
	{
		private readonly IBaseCRUDProvider<TModel> _provider;

		protected CrudManager(IBaseCRUDProvider<TModel> provider)
		{
			_provider = provider;
		}

		public virtual TModel Insert(TModel model)
		{
			return _provider.Insert(model);
		}

		public virtual TModel Update(TModel model)
		{
			return _provider.Update(model);
		}

		public virtual bool Delete(Guid modelGuid)
		{
			return _provider.Delete(modelGuid);
		}

		public virtual TModel GetById(Guid modelGuid)
		{
			return _provider.GetById(modelGuid);
		}

		public IQueryable<TModel> CollectionModels
		{
			get { return _provider.CollectionModels; }
		}
	}
}