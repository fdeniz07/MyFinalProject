using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        #region Kötü kodun daha okunur ve kullanisli hale getirilmesi

        //var context = new ValidationContext<Product>(product);
        //ProductValidator productValidator = new ProductValidator();

        //var result = productValidator.Validate(context);
        //    if (!result.IsValid)
        //{
        //    throw new ValidationException(result.Errors);
        //}

        #endregion

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}


