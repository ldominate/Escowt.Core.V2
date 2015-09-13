using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Escowt.Domain.ResourceCodeString;

namespace Escowt.Domain.Validation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
	{
		public string ErrorMessageId { get; set; }

		private readonly Type _resourceType;

		public RequiredAttribute()
		{
			_resourceType = typeof(IResourceCodeString);
			ErrorMessageId = "Required";
		}

		private IResourceCodeString Service { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Service = validationContext.GetService(_resourceType) as IResourceCodeString;

			var array = value as IEnumerable;

			if (array != null)
			{
				var isEmpty = !array.Cast<object>().Any();

				if (isEmpty)
				{
					return new ValidationResult(GetArrayEmpty(validationContext), new[] {validationContext.MemberName});
				}
			}
			if (value != null && value.GetType().IsEnum && (int) value == 0)
			{
				return new ValidationResult(GetEnumEmpty(validationContext), new[] {validationContext.MemberName});
			}
			return base.IsValid(value, validationContext);
		}

		string GetArrayEmpty(ValidationContext context)
		{
			ErrorMessageId = "MustNotEmptyCollection";
			return FormatErrorMessage(context.DisplayName);
		}

		string GetEnumEmpty(ValidationContext context)
		{
			ErrorMessageId = "MustSelectValue";
			return FormatErrorMessage(context.DisplayName);
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(Service.GetString(ErrorMessageId), name);
		}
	}
}
