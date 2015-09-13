using System;
using System.ComponentModel.DataAnnotations;

namespace Escowt.Domain.Validation
{
	/// <summary>Свойство должно быть уникально</summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	public class UniqueAttribute : BaseValidateAttribute
	{
		public override bool Match(object obj)
		{
			return obj is UniqueAttribute;
		}

		public UniqueAttribute()
		{
			ErrorMessage = "MustUnique";
		}

		public override bool IsValid(object value)
		{
			return true;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			return ValidationResult.Success;
		}
	}
}
