using System.ComponentModel.DataAnnotations;

namespace real_estate.Custom_Validation
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (propertyInfo == null)
            {
                return new ValidationResult($"Property with name {_comparisonProperty} not found.");
            }

            var comparisonValue = propertyInfo.GetValue(validationContext.ObjectInstance);
            if (value == null || comparisonValue == null)
            {
                return new ValidationResult($"please enter the {validationContext.DisplayName}");
            }

            if ((DateTime)value <= (DateTime)comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? $"The {validationContext.DisplayName} must be greater than {_comparisonProperty}.");
            }

            return ValidationResult.Success;
        }
    }
}
