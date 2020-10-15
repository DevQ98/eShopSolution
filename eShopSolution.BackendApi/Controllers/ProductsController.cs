using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // https://localhost:port/products?pageIndex=1&pageSize=1&CategoryId=
        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(languageId , request);
            return Ok(products);
        }
        // https://localhost:port/product/id
        [HttpGet("{productId}/{languageId}")] 
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Can't found");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.Create(request);
            if (result == 0)
                return BadRequest();
            var Product = await _manageProductService.GetById(result , request.LanguageId);
            return Created(nameof(GetById), Product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            
            return Ok();
        }
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice )
        {
            var isSuccess = await _manageProductService.UpdatePrice(productId, newPrice);
            if (isSuccess )
                return Ok();

            return BadRequest();
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
        // Image
        [HttpPost("{productId}/imgaes")]
        public async Task<IActionResult> CreateImage(int productId , [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductService.AddImage( productId, request);
            if (imageId == 0)
                return BadRequest();
            var image = await _manageProductService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new {id =  imageId } , image);
        }
        [HttpPut("{productId}/imgaes/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage( imageId, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{productId}/imgaes/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            var affectedResult = await _manageProductService.RemoveImage(imageId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpGet("{productId}/image/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId ,  int imageId)
        {
            var image = await _manageProductService.GetImageById( imageId);
            if (image == null)
                return BadRequest("Can't found");
            return Ok(image);
        }
    }
}
