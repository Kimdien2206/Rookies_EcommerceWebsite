using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;

namespace Rookies_EcommerceWebsite.Services
{
    public class CartService : IService<Cart>
    {
        private readonly IRepository<Cart> _repository;
        private readonly UnitOfWork _unitOfWork;

        public CartService(IRepository<Cart> repository, UnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IResult> Create(Cart entity)
        {
            Variant variant = await _unitOfWork.variantRepository.GetById(entity.VariantId);
            if(variant == null)
            {
                return Results.NotFound(variant);
            }
            Product product = await _unitOfWork.productRepository.GetById(variant.ProductId);

            if(product == null)
            {
                return Results.NotFound(product);
            }

            entity.TotalCost = (ulong)(entity.Amount * product.Price);

            Cart cart = await _unitOfWork.cartRepository.Create(entity);
            _unitOfWork.SaveChanges();

            if(cart == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(cart);
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
