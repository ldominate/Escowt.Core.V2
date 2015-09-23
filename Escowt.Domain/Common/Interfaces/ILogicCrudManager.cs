using System;

namespace Escowt.Domain.Common.Interfaces
{
	public interface ILogicCrudManager<TModel> : ICrudManager<TModel> where TModel : BaseDomainByLogicDeleteObject
	{
		/// <summary>Логическое удаление</summary>
		/// <remarks>Пометка объекта на удаление</remarks>
		/// <param name="modelGuid">Идентификатор модели</param>
		/// <returns></returns>
		bool LogicDelete(Guid modelGuid);

		/// <summary>Логическое восстановление</summary>
		/// <remarks>Снятие пометки на удаление</remarks>
		/// <param name="modelGuid">Идентификатор модели</param>
		/// <returns></returns>
		bool LogicRecover(Guid modelGuid);

	}
}