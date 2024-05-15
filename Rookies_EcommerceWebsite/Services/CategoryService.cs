using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Category entity)
        {
            Category cart = await _repository.Insert(entity);
            await _repository.Save();

            if (cart == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(cart);
        }

        public async Task<IResult> Delete(string id)
        {
            Task task = _repository.Delete(id);

            if (task.IsCompleted)
            {
                return Results.Ok();
            }

            return Results.UnprocessableEntity();
        }

        public async Task<IResult> GetAll()
        {
            List<Category> carts = await _repository.GetAll();

            if (carts == null || carts.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(carts);
        }

        public async Task<IResult> GetById(string id)
        {
            Category cart = await _repository.GetById(id);

            if (cart == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(cart);
        }

        public async Task<IResult> Update(string id, Category entity)
        {
            Category updatedCategory = await _repository.Update(id, entity);
            await _repository.Save();

            if (updatedCategory == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedCategory);
        }
    }
}
