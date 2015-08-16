﻿
using System.Collections.Generic;
using Shop.Domain.Entities;

namespace Shop.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetTenProducts(int startIndex);
        int GetProductsCount();
        void Save(List<Product> products);
        Product Save(Product product);
    }
}
