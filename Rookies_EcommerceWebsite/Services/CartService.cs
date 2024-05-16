using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class CartService : IService<Cart>
    {
        private readonly IRepository<Cart> _repository;

        public CartService(IRepository<Cart> repository)
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Cart entity)
        {
            Cart cart = await _repository.Create(entity);
            await _repository.Save();

            if(cart == null)
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
            List<Cart> carts = await _repository.GetAll();

            if(carts == null || carts.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(carts);
        }

        public async Task<IResult> GetById(string id)
        {
            Cart cart = await _repository.GetById(id);

            if (cart == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(cart);
        }

        public async Task<IResult> Update(string id, Cart entity)
        {
            Cart updatedCart = await _repository.Update(id, entity);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedCart);
        }
    }
}
