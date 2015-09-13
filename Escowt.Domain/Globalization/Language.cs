using Escowt.Domain.Common;
using Escowt.Domain.Validation;

namespace Escowt.Domain.Globalization
{
	public class Language : BaseDomainObject
	{
		public Language()
		{
			
		}

		[Required]
		public string Alias { get; set; }

		public string TitleRu { get; set; }

		public string TitleEn { get; set; }

		public string Description { get; set; }

		public override string ToString()
		{
			return TitleEn;
		}
	}
}
