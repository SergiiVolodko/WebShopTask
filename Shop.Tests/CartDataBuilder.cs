﻿using System;
using System.Collections.Generic;
using Shop.Domain.Entities;

namespace Shop.Tests
{
    public class CartDataBuilder
    {
        private readonly Cart cart;

        public CartDataBuilder()
        {
            cart = new Cart();
            cart.Products = new List<Prdouct>();
        }

        public CartDataBuilder WithProduct(Prdouct prdouct)
        {
            cart.Products.Add(prdouct);
            return this;
        }

        public CartDataBuilder WithEmptyId()
        {
            cart.Id = null;
            return this;
        }
        
        public CartDataBuilder WithSomeId()
        {
            cart.Id = Guid.NewGuid();
            return this;
        }

        public CartDataBuilder WithId(Guid cartId)
        {
            cart.Id = cartId;
            return this;
        }

        public Cart Build()
        {
            return cart;
        }
    }
}
