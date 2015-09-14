using System.Collections.Generic;
using Escowt.Domain.Common;
using Escowt.Domain.Validation;

namespace Escowt.Domain.Authorization
{
	public class UserGroup : BaseEntity<UserGroupCaption>
	{
		public UserGroup()
		{
			Titles = new HashSet<UserGroupCaption>();
		}

		[Required, Unique, StringLength(50)]
		public string Name { get; set; }

	}
}
