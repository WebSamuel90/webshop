using System.Linq;
using System.Transactions;
using NUnit.Framework;
using webshop.Modals;
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
                id = 15,
                name = "puma one 18.1 fg",
                image = "https://www.stadium.se/INTERSHOP/static/WFS/Stadium-SwedenB2C-Site/-/Stadium/sv_SE/Detail/256805_103_PUMA_PUMA%20ONE%2018.1%20FG.png",
                brand = "Puma",
                price = 1999
            };

            //Act
            var results = this.productsService.Get(productItem.id);

            //Assert
            Assert.That(results.id, Is.EqualTo(productItem.id));
            Assert.That(results.name, Is.EqualTo(productItem.name));
            Assert.That(results.image, Is.EqualTo(productItem.image));
            Assert.That(results.brand, Is.EqualTo(productItem.brand));
            Assert.That(results.price, Is.EqualTo(productItem.price));
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
                id = ExpectedId,
                name = ExpectedName,
                image = ExpectedImage,
                brand = ExpectedBrand,
                price = ExpectedPrice
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

            Assert.That(addedItem.id, Is.EqualTo(product.id));
            Assert.That(addedItem.name, Is.EqualTo(product.name));
            Assert.That(addedItem.image, Is.EqualTo(product.image));
            Assert.That(addedItem.brand, Is.EqualTo(product.brand));
            Assert.That(addedItem.price, Is.EqualTo(product.price));

            Assert.That(addedItem.id, Is.AtLeast(1));
        }
    }
}
