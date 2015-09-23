using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escowt.Data.Common.Managers
{
	public abstract class BaseManager
	{

		public virtual DateTime GetCurrentDateTime()
		{
			return DateTime.Now;
		}
	}
}
