using System;
using System.Linq;

namespace Escowt.Domain.Common.Interfaces
{
	public interface ICrudManager<TModel> where TModel : BaseDomainObject
	{
		TModel Insert(TModel model);

		TModel Update(TModel model);

		bool Delete(Guid modelGuid);

		/// <summary>Получить модель полностью с вложенными под объектами</summary>
		/// <param name="modelGuid"></param>
		/// <returns></returns>
		TModel GetById(Guid modelGuid);

		IQueryable<TModel> CollectionModels { get; }

	}
}