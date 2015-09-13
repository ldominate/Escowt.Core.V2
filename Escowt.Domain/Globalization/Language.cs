using Escowt.Domain.Common;
using Escowt.Domain.Validation;

namespace Escowt.Domain.Globalization
{
	public class Language : BaseDomainObject
	{
		public Language()
		{
			
		}

		[Required, StringLength(10)]
		public string Alias { get; set; }

		[StringLength(50)]
		public string TitleRu { get; set; }

		[StringLength(50)]
		public string TitleEn { get; set; }

		[StringLength(1024)]
		public string Description { get; set; }

		public override string ToString()
		{
			return TitleEn;
		}
	}
}
