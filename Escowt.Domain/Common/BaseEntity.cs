using System;
using System.Collections.Generic;
using System.Linq;

namespace Escowt.Domain.Common
{
	public abstract class BaseEntity<TCaption> : BaseDomainObject
		where TCaption : Caption
	{
		public ICollection<TCaption> Titles { get; set; }

		/// <summary>Получить наименование объекта</summary>
		/// <param name="alias">Псевдоним языка</param>
		/// <returns></returns>
		public virtual string GetTitle(string alias)
		{
			return GetTitleCaption(i => i.Language.Alias == alias);
		}

		/// <summary>Получить наименование объекта</summary>
		/// <param name="languageGuid">Идентификатор языка</param>
		/// <returns></returns>
		public virtual string GetTitle(Guid languageGuid)
		{
			return GetTitleCaption(i => i.Language.Guid == languageGuid);
		}

		string GetTitleCaption(Func<TCaption, bool> matchingFunc)
		{
			if (Titles == null || !Titles.Any())
			{
				return string.Empty;
			}
			var result = Titles.FirstOrDefault(matchingFunc);

			if (result != null)
			{
				return result.Title;
			}
			return string.Empty;
		}

		/// <summary>Получить наименование объекта по умолчанию</summary>
		/// <returns></returns>
		public virtual string GetTitle()
		{
			var result = Titles.FirstOrDefault();

			if (result != null)
			{
				return result.Title;
			}
			return string.Empty;
		}

		/// <summary>Получить наименование объекта по умолчанию</summary>
		/// <returns></returns>
		public override string ToString()
		{
			return GetTitle();
		}

		public Caption DefaultCaption
		{
			get { return Titles.FirstOrDefault(); }
		}

	}
}
