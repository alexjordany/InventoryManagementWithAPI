﻿namespace InventoryManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandResponse : BaseResponse
{
    public CreateProductCommandResponse() : base()
    {
    }

    public CreateProductDto Product { get; set; }
}
