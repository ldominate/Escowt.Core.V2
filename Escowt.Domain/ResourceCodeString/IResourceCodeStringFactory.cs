using System;

namespace Escowt.Domain.ResourceCodeString
{
	/// <summary>Описание фабрики поставщиков строк</summary>
	public interface IResourceCodeStringFactory
	{
		/// <summary>Создаёт поставщика строк</summary>
		/// <param name="codeString">Тип кода строки</param>
		/// <returns>Поставщик строк</returns>
		IResourceCodeString CreateResource(Type codeString);
	}
}
