using FluentValidation;

namespace SimpleShop.src.Api.Models.Validators;
#pragma warning disable CS1591
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(40)
            .MinimumLength(1)
            .WithMessage("Product's title must be between 1 and 40");

        RuleFor(x => x.Price)
            .GreaterThan(1)
            .WithMessage("Product's price must be grater than the 1");

        RuleFor(x => x.Discount)
            .LessThan(100)
            .WithMessage("Product's discount must be less then the 100");

        RuleFor(x => x.InventoryCount)
            .GreaterThan(1)
            .WithMessage("Product's quantity must be grater than the 1");
    }
}