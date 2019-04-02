using System.Linq;
using System.Transactions;
using NUnit.Framework;
using webshop.Models;
using webshop.Repositories;
using webshop.Services;

namespace webshop.IntegrationTests.Services
{
    public class ProductsServiceTests
    {
        private ProductsService productsService;

        [SetUp]
        public void SetUp()
        {
            this.productsService = new ProductsService(new ProductsRepository(
                "Server=localhost;Port=8889;;Database=webshop;Uid=root;Pwd=root;"));
        }

        [Test]
        public void Get_ReturnsResultsFromDatabase()
        {
            // Act
            var results = this.productsService.Get().Count;
            // Assert
            Assert.That(results, Is.EqualTo(15));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            var productItem = new Product
            {
                product_id = 15,
                product_name = "puma one 18.1 fg",
                product_image = "https://www.stadium.se/INTERSHOP/static/WFS/Stadium-SwedenB2C-Site/-/Stadium/sv_SE/Detail/256805_103_PUMA_PUMA%20ONE%2018.1%20FG.png",
                product_brand = "Puma",
                product_price = 1999
            };

            //Act
            var results = this.productsService.Get(productItem.product_id);

            //Assert
            Assert.That(results.product_id, Is.EqualTo(productItem.product_id));
            Assert.That(results.product_name, Is.EqualTo(productItem.product_name));
            Assert.That(results.product_image, Is.EqualTo(productItem.product_image));
            Assert.That(results.product_brand, Is.EqualTo(productItem.product_brand));
            Assert.That(results.product_price, Is.EqualTo(productItem.product_price));
        }

        [Test]
        public void Add_GivenValidProductItem_SavesIt()
        {
            // Arrange
            const int ExpectedId = 16;
            const string ExpectedName = "Total90";
            const string ExpectedImage = "anUrl";
            const string ExpectedBrand = "Nike";
            const int ExpectedPrice = 799;

            var product = new Product
            {
                product_id = ExpectedId,
                product_name = ExpectedName,
                product_image = ExpectedImage,
                product_brand = ExpectedBrand,
                product_price = ExpectedPrice
            };

            // Act
            Product addedItem;
            using (new TransactionScope())
            {
                this.productsService.Add(product);

                addedItem = this.productsService.Get().Last();
            }

            // Assert
            Assert.IsNotNull(addedItem);

            Assert.That(addedItem.product_id, Is.EqualTo(product.product_id));
            Assert.That(addedItem.product_name, Is.EqualTo(product.product_name));
            Assert.That(addedItem.product_image, Is.EqualTo(product.product_image));
            Assert.That(addedItem.product_brand, Is.EqualTo(product.product_brand));
            Assert.That(addedItem.product_price, Is.EqualTo(product.product_price));

            Assert.That(addedItem.product_id, Is.AtLeast(1));
        }
    }
}
