using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using ShopBridge.API.Helper;
using ShopBridge.Core.Entity.Common;
using ShopBridge.Core.Entity.Inventory;
using ShopBridge.Core.Service.Inventory;

namespace ShopBridge.API.Controllers.Inventory
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _IProductService;

        /// <summary>
        ///  Inject the required dependency in the Product Controller
        ///  So that we use the services as usual
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="logger"></param>
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _IProductService = productService;
            _logger = logger;
        }

        /// <summary>
        /// API End point to create the product detail
        /// </summary>
        /// <param name="modelEntity"></param>
        /// <returns></returns>
        [HttpPost("api/Product/Create")]
        [Produces("application/json")]
        [Consumes("application/json")]

        
        public async Task<IActionResult> CreateProduct(Product modelEntity)
        {
            try
            {
                var response = await _IProductService.CreateEntity(modelEntity);
                return Ok(Message.AppSetting["ProductCreated"]);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in Dashboard Index {ex.Message}");
                return Problem(Message.AppSetting["Exception"]);
            }
        }

        /// <summary>
        /// Get Product Detail by pagging,You need to pass the current page index and record count
        /// for this page.
        /// currentPage =1, recordCount=10 => means display the total 10 record from page index 1
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        [HttpGet("api/Product/GetProducts")]
        [Produces("application/json")]
        [Consumes("application/json")]

        public async Task<IActionResult> GetProducts(int currentPage, int recordCount)
        {
            try
            {
                var response = await _IProductService.GetEntityList(currentPage, recordCount);
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in Dashboard Index {ex.Message}");
                return Problem(Message.AppSetting["Exception"]);
            }

        }


        /// <summary>
        /// Update the Product Detail, Pass the required fields and it will update the Product
        /// with provided information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelEntity"></param>
        /// <returns></returns>
        [HttpPut("api/Product/Update")]
        [Produces("application/json")]
        [Consumes("application/json")]

        public async Task<IActionResult> UpdateProduct([FromBody] Product modelEntity)
        {
            try
            {
                var response = await _IProductService.UpdateEntity(modelEntity);
                return Ok(Message.AppSetting["ProductUpdated"]);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in Dashboard Index {ex.Message}");
                return Problem(Message.AppSetting["Exception"]);
            }

        }

        /// <summary>
        /// Delete the Product Information you need to pass the product ID and based on this ProductId
        /// It will delete the Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("api/Product/Delete")]
        [Produces("application/json")]
        [Consumes("application/json")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                ResponseMessage response = await _IProductService.DeleteEntity(id);
                var result = response == ResponseMessage.NotFound ? BadRequest("Record not found") :
                    response == ResponseMessage.Deleted ? Ok(Message.AppSetting["ProductDeleted"]) : Problem("exception");
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in Dashboard Index {ex.Message}");
                return Problem(Message.AppSetting["Exception"]);
            }

        }


        /// <summary>
        /// End point which expose to the single Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/Product/GetProductId")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> ProductDetailById(int id)
        {
            try
            {
                var response = await _IProductService.GetSingle(x => x.Id == id);

                if (response == null)
                    return BadRequest(Message.AppSetting["ProductNotFound"]);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in Dashboard Index {ex.Message}");
                return Problem(Message.AppSetting["Exception"]);
            }
        }
    }
}

