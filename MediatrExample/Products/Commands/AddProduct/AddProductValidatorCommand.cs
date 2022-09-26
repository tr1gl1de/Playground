using FluentValidation;

namespace MediatrExample.Products.Commands.AddProduct;

public sealed class AddProductValidatorCommand : AbstractValidator<AddProductCommand>
{
    public AddProductValidatorCommand()
    {
        RuleFor(x => x.Product.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Product.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200);
    }
}