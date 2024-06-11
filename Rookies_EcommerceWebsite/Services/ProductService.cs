using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Dtos;

namespace Rookies_EcommerceWebsite.Services
{
    public class ProductService 
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            this._repository = repository;
        }



        public async Task<IResult> Create(Product creatingProduct)
        {
            Product createdProduct = await _repository.Create(creatingProduct);
            await _repository.Save();

            if (createdProduct == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdProduct);
        }

        public async Task<IResult> Delete(string id)
        {
            _repository.Delete(id);
            Task task = _repository.Save();
            task.Wait();

            if (task.IsCompleted)
            {
                return Results.Ok();
            }

            return Results.UnprocessableEntity();
        }

        public async Task<IResult> GetBySlug(string slug)
        {
            Product product = (await _repository.Get(x => x.Slug == slug, null, "Variants,Ratings")).FirstOrDefault();
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }
        
        public async Task<IResult> GetPageQuantity()
        {
            int productCount = (await _repository.Get()).Count();

            int quantity = (int)Math.Ceiling((double)productCount/9);
            
            return Results.Ok(quantity);
        }
        
        public async Task<IResult> GetUpcoming()
        {
            List<Product> products = await _repository.Get();
            if (products == null)
            {
                return Results.NotFound();
            }

            List<Product> upcoming = products.OrderByDescending(u => u.CreatedDate).Take(5).ToList();
            return Results.Ok(upcoming);
        }

        public async Task<IResult> GetPage(string page)
        {
            try
            {
                int pageIndex = Int16.Parse(page);
                if (pageIndex >= 0)
                {
                    List<Product> products = await _repository.Get(x => true, p => p.OrderBy(a => a.CreatedDate).Skip((pageIndex - 1) * 9).Take(9));
                    if (products == null || products.Count == 0)
                    {
                        return Results.NoContent();
                    }
                    return Results.Ok(products);
                }
                else
                {
                    return Results.BadRequest();
                }

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IResult> Update(string id, Product updatingProduct)
        {
            Product updatedProduct = await _repository.Update(id, updatingProduct);
            Task task = _repository.Save();
            task.Wait();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity(updatingProduct);
            }

            return Results.Ok(updatedProduct);
        }
    }
}
