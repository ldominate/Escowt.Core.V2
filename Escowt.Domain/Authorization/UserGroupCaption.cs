using System;
using System.ComponentModel.DataAnnotations;
using Escowt.Domain.Common;

namespace Escowt.Domain.Authorization
{
	/// <summary>Наименование группы пользователей</summary>
	public class UserGroupCaption : Caption
	{
		/// <summary>Идентификатор группы пользователей</summary>
		/// <remarks>Связь</remarks>
		[Key]
		public Guid UserGroupGuid { get; set; }
	}
}
