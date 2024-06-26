﻿using BL.DTOs;
using BL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Products
{
    public  interface IProductManager
    {
        IEnumerable<ProductReadDto> GetProducts(string? Name, string? Category);
        ProductAddDto addProduct(ProductAddDto productAddDto);
        ProductReadDto? GetProductDetails(int id);
    }
}
