using System;
using System.ComponentModel.DataAnnotations;
using Escowt.Domain.ResourceCodeString;

namespace Escowt.Domain.Validation
{
	/// <summary>Атрибут проверки данных для свойства</summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	public abstract class BaseValidateAttribute : ValidationAttribute
	{
		public string ErrorMessageId { get; set; }

		private readonly Type _resourceType;

		protected BaseValidateAttribute()
		{
			_resourceType = typeof(IResourceCodeString);
		}

		private IResourceCodeString Service { get; set; }

		public override string FormatErrorMessage(string name)
		{
			return string.Format(Service.GetString(ErrorMessageId), name);
		}

	}
}
