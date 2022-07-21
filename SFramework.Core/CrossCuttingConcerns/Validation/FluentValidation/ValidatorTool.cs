using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace SFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate<T>(IValidator validator, T entity)
        {
            var context = new ValidationContext<T>(entity);
            var result = validator.Validate(context);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
