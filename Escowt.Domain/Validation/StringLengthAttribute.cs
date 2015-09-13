using System;
using System.ComponentModel.DataAnnotations;
using Escowt.Domain.ResourceCodeString;

namespace Escowt.Domain.Validation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
	{
		private const string ErrorMessageId = "LengthString";

		readonly Type _resourceType;

		public StringLengthAttribute(int maximumLength) : base(maximumLength)
		{
			_resourceType = typeof(IResourceCodeString);
		}

		private IResourceCodeString Service { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Service = validationContext.GetService(_resourceType) as IResourceCodeString;
			var str = value as string;
			if (str != null)
			{
				if (string.IsNullOrWhiteSpace(str))
					return ValidationResult.Success;
				value = str.Trim();
			}
			return base.IsValid(value, validationContext);
		}

		public override string FormatErrorMessage(string name)
		{
			return string.Format(Service.GetString(ErrorMessageId), name, MinimumLength, MaximumLength);
		}
	}
}
