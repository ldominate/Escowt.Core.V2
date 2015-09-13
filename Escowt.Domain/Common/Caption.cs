using Escowt.Domain.Globalization;
using Escowt.Domain.Validation;

namespace Escowt.Domain.Common
{
	/// <summary>Наименование объекта</summary>
	public class Caption
	{
		/// <summary>Значение наименования</summary>
		[Required, StringLength(255)]
		public virtual string Title { get; set; }

		/// <summary>Описание</summary>
		[StringLength(1024)]
		public virtual string Description { get; set; }

		[Required]
		public Language Language { get; set; }

	}
}
