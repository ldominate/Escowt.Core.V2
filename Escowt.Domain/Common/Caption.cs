using System;
using System.ComponentModel.DataAnnotations;
using Escowt.Domain.Globalization;

namespace Escowt.Domain.Common
{
	/// <summary>Наименование объекта</summary>
	public class Caption
	{
		/// <summary>Идентификатор языка</summary>
		/// <remarks>Связь</remarks>
		[Key]
		public Guid LanguageGuid { get; set; }

		/// <summary>Значение наименования</summary>
		[Validation.Required, Validation.StringLength(255)]
		public virtual string Title { get; set; }

		/// <summary>Описание</summary>
		[Validation.StringLength(1024)]
		public virtual string Description { get; set; }

		[Validation.Required]
		public Language Language { get; set; }

	}
}
