using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ShopBridge.Core.Entity.Inventory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.API.Test
{
    public class ProductTest
    {
        private readonly HttpClient _client;

        public ProductTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task GetAllProduct()
        {
            var response = await _client.GetAsync(@"api/Product/GetProducts?currentPage=1&recordCount=10");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct()
        {
            var response = await _client.DeleteAsync(@"api/Product/DeleteProduct?id=1");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct()
        {
            Product prod = new Product()
            {
                ProductName = "Testproduct",
                Description = "TestProductDescription",
                Price = 253,
                SKUCode = "TestSKUProduct",
                IsActive = true,
                IsDeleted =0,
                CreatedBy = 1,
                CreatedDate = DateTime.Now.Date,
                UpdatedBy = 0,
                UpdatedDate = DateTime.Now.Date

            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(prod), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync(@"api/Product/Create", httpContent);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }



    }
}
