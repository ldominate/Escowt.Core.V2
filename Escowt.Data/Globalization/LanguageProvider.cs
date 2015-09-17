using Escowt.Data.Common.Providers;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Globalization
{
	public class LanguageProvider : BaseCRUDProvider<Language>, ILanguageProvider
	{
		public LanguageProvider(EscowtDB contextDB) : base(contextDB)
		{

		}

	}
}
