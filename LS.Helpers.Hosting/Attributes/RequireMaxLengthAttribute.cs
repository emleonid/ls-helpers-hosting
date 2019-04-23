using System.ComponentModel.DataAnnotations;

namespace LS.Helpers.Hosting.Attributes
{
    /// <summary>
    /// Max length attribute for model validation
    /// </summary>
    /// <seealso cref="ValidationAttribute" />
    public class RequireMaxLengthAttribute : ValidationAttribute
    {
        private readonly int _maxlength;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequireMaxLengthAttribute"/> class.
        /// </summary>
        /// <param name="maxlength">The maxlength.</param>
        public RequireMaxLengthAttribute(int maxlength)
        {
            _maxlength = maxlength;
        }

        /// <inheritdoc />
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value is string str)
            {
                if (str.Length > _maxlength)
                {
                    var errorMessage = $"{validationContext.MemberName} length can't be more than {_maxlength}.";
                    return new ValidationResult(errorMessage);
                }
            }
            else
            {
                return new ValidationResult($"{validationContext.MemberName} should be string type");
            }

            return ValidationResult.Success;
        }
    }
}
