﻿using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using webshop.Models;
using webshop.Repositories;
using webshop.Services;

namespace webshop.UnitTests
{
    public class ProductServiceTests
    {

        private IProductsRepository productsRepository;
        private ProductsService productsService;

        [SetUp]
        public void SetUp()
        {
            this.productsRepository = A.Fake<IProductsRepository>();
            this.productsService = new ProductsService(this.productsRepository);
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // Arrange
            var productItem = new Product
            {
                product_id = 20,
                product_name = "Total90",
                product_image = "anUrl",
                product_brand = "Adidas",
                product_price = 799
            };

            var productItems = new List<Product>
            {
                productItem
            };

            A.CallTo(() => this.productsRepository.Get()).Returns(productItems);

            // Act
            var result = this.productsService.Get().Single();

            // Assert
            Assert.That(result, Is.EqualTo(productItem));

        }

        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange
            var Id = 20;

            var productItem = new Product
            {
                product_id = Id,
                product_name = "Total90",
                product_image = "anUrl",
                product_brand = "Nike",
                product_price = 799
            };

            A.CallTo(() => this.productsRepository.Get(Id)).Returns(productItem);

            // Act
            var result = this.productsService.Get(Id);

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}
