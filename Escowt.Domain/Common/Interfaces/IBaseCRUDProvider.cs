using System;
using System.Linq;
using System.Linq.Expressions;

namespace Escowt.Domain.Common.Interfaces
{
	/// <summary>Общий интерфейс доступа к данным</summary>
	/// <typeparam name="TModel"></typeparam>
	public interface IBaseCRUDProvider<TModel> where TModel : BaseDomainObject
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
