namespace Escowt.Domain.ResourceCodeString
{
	/// <summary>Описание поставщика строк по коду строки</summary>
	public interface IResourceCodeString
	{
		/// <summary>Базовый метод возвращающий строку описания по её коду</summary>
		/// <param name="codeString"></param>
		/// <returns></returns>
		string GetString(object codeString);
	}
}
