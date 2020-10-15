﻿using System.Collections.Generic;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId ,GetPublicProductPagingRequest request);

    }
}
