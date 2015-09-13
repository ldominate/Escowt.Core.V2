using System;
using System.ComponentModel.DataAnnotations;

namespace Escowt.Domain.Common
{
	public abstract class BaseDomainObject : IEquatable<BaseDomainObject>
	{
		protected BaseDomainObject()
		{
			Guid = Guid.NewGuid();
		}

		/// <summary>Идентификатор объекта</summary>
		[Key]
		public Guid Guid { get; set; }

		public bool Equals(BaseDomainObject other)
		{
			return other != null && other.Guid == Guid && GetType() == other.GetType();
		}
	}
}
