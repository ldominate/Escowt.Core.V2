using System;

namespace Escowt.Domain.Common.Interfaces
{
	/// <summary>Общий интерфейс доступа к данным модели с логическим удалением</summary>
	/// <typeparam name="TModel"></typeparam>
	public interface IBaseCRUDLogicProvider<TModel> : IBaseCRUDProvider<TModel>
		where TModel : BaseDomainByLogicDeleteObject
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
