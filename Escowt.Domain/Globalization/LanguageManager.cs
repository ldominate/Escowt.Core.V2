using Escowt.Domain.Common.Managers;

namespace Escowt.Domain.Globalization
{
	public class LanguageManager : LogicCrudManager<Language>, ILanguageManager
	{
		public LanguageManager(ILanguageProvider provider) : base(provider)
		{
			
		}

	}
}
