﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq.Expressions;
using Escowt.Data.Common.Providers;
using Escowt.Domain.Globalization;

namespace Escowt.Data.Globalization
{
	public class LanguageProvider : BaseCRUDLogicProvider<Language>, ILanguageProvider
	{
		public LanguageProvider(EscowtDB contextDB) : base(contextDB)
		{

		}

		public override Language Insert(Language model)
		{
			return Insert(model, l => l.IsDeleted);
		}

		public override Language Update(Language model)
		{
			return Update(model, l => l.Alias, language => language.IsDeleted);
		}
	}
}
