﻿using InventoryManagement.Application.Features.Inventories.Commands.CreateInventory;
using InventoryManagement.Application.Features.Inventories.Commands.UpdateInventory;
using InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesByName;
using InventoryManagement.Application.Features.Inventories.Queries.GetInventoriesList;
using InventoryManagement.Application.Features.Inventories.Queries.GetInventoryDetail;

namespace InventoryManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Inventory, CreateInventoryDto>().ReverseMap();
        CreateMap<Inventory, InventoryListVM>().ReverseMap();
        CreateMap<Inventory, InventoryByNameVM>().ReverseMap();
        CreateMap<Inventory, InventoryDetailVM>().ReverseMap();
        CreateMap<Inventory, UpdateInventoryCommand>().ReverseMap();
        CreateMap<Inventory, UpdateInventoryDto>().ReverseMap();
    }
}

