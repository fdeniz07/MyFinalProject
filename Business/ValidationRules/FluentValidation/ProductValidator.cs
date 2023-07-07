using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).MaximumLength(20);

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile baslamali!");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}


#region Mesajlar Alanlar ve Degerleri Türkce kullanilacaksa

/*
 *  RuleFor(p => p.ProductName).NotEmpty().WithName("Ürün Adı").WithMessage("{PropertyName}" + ValidatorMessages.NotEmpty);
    RuleFor(p => p.ProductName).MinimumLength(2).WithName("Ürün Adı").WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotShorterChar, "{PropertyValue}"));
    RuleFor(p => p.ProductName).MaximumLength(20).WithName("Ürün Adı").WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotLongerChar, "{PropertyValue}"));

    RuleFor(p => p.UnitPrice).NotEmpty().WithName("Ürün Fiyatı").WithMessage("{PropertyName} {}" + ValidatorMessages.NotEmpty);
    RuleFor(p => p.UnitPrice).GreaterThan(0).WithName("Ürün Fiyatı").WithMessage("{PropertyName}" + String.Format(ValidatorMessages.NotSmallerNum, "{PropertyValue}"));
    RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).WithName("Ürün Fiyatı").When(p => p.CategoryId == 1).WithMessage("{PropertyName}" + String.FormatValidatorMessages.NotSmallerNum, "{PropertyValue}"));
 */

#endregion