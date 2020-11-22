using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Product;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetProductById(long id)
        {
            try
            {
                var productId = await _productRepository.GetById(id);

                return Ok(productId);
            }
            catch (Exception e)
            {
                return NotFound("The Product was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var allProducts = await _productRepository.GetAll();

                return Ok(allProducts);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(ProductCreationDto dto)
        {
            var newProduct = new ProductCreationDto
            {
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                //ProductPhoto = dto.ProductPhoto,
                DiscountStock = dto.DiscountStock,
                Discontinued = dto.Discontinued,
                ShowBrand = dto.ShowBrand,
                Slow = dto.Slow,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                Price1 = dto.Price1,
                Stock = dto.Stock
            };

            await _productRepository.Create(newProduct);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct(ProductCreationDto dto)
        {
            try
            {
                var update = new ProductCreationDto
                {
                    Code = dto.Code,
                    Name = dto.Name,
                    Description = dto.Description,
                    //ProductPhoto = dto.ProductPhoto,
                    DiscountStock = dto.DiscountStock,
                    Discontinued = dto.Discontinued,
                    ShowBrand = dto.ShowBrand,
                    Slow = dto.Slow,
                    BrandId = dto.BrandId,
                    CategoryId = dto.CategoryId,
                    Price1 = dto.Price1,
                    Stock = dto.Stock
                };

                await _productRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Product cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteProduct(ProductCreationDto dto)
        {
            try
            {
                await _productRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Product cannot be delete");
            }
        }
    }
}
