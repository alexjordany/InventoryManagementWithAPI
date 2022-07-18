﻿using FluentValidation;

namespace InventoryManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Quantity must be greater or equal to 0");

        When(p => p.ProductInventories == null || p.ProductInventories.Count <= 0, () =>
        {
            RuleFor(p => p.Price).GreaterThanOrEqualTo(0);
        }).Otherwise(() =>
        {
            RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(p => p.ProductInventories.Sum(x => x.Inventory.Price * x.InventoryQuantity))
            .WithMessage("The price of the product is less than the sum of the price of the inventories which is: {ComparisonValue}");
        });
    }
}

