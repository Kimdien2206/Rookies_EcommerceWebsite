using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            List<Product> products = await _repository.GetAll();
            if (products == null || products.Count == 0)
            {
                return Results.NoContent();
            }
            return Results.Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetById(string id)
        {
            Product product = await _repository.GetById(id);
            if(product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            Product newProduct = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Images = productDto.Images,
                Slug = productDto.Slug,
                CategoryId = productDto.CategoryId
            };
            Product createdProduct = await _repository.Create(newProduct);

            if(createdProduct == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdProduct);  
        }

        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IResult> Update(string id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        //{
        //    Product updateProduct = new Product()
        //    {

        //    };
        //    Product updatedProduct = await _repository.Update();
        //}
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            Task task = _repository.Delete(id);

            if(task.IsCompleted)
            {
                return Results.Ok();
            }
            
            return Results.UnprocessableEntity();
        }
    }
}
