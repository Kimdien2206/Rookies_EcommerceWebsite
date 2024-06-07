﻿using AutoMapper;
using Dtos.Response;
using Rookies_EcommerceWebsite.API.Interfaces;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;

namespace Rookies_EcommerceWebsite.Services
{
    public class CartService
    {
        private readonly IRepository<Cart> _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> repository, UnitOfWork unitOfWork, IMapper mapper)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IResult> Create(Cart entity)
        {
            Variant variant = _unitOfWork.variantRepository.GetById(entity.VariantId);
            if(variant == null)
            {
                return Results.NotFound(variant);
            }

            Product product = _unitOfWork.productRepository.GetById(variant.ProductId);
            if(product == null)
            {
                return Results.NotFound(product);
            }

            Cart cart = await _unitOfWork.cartRepository.SearchIfExistCart(entity.CustomerId, entity.VariantId);
            if (cart != null)
            {
                cart.Amount += entity.Amount;
                cart.TotalCost = (ulong)(cart.Amount * product.Price);
                _unitOfWork.SaveChanges();
                return Results.Ok(cart);
            }

            entity.TotalCost = (ulong)(entity.Amount * product.Price);

            Cart createdCart = await _unitOfWork.cartRepository.Create(entity);
            _unitOfWork.SaveChanges();

            if(createdCart == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdCart);
        }

        public async Task<IResult> Delete(string id)
        {
            Task task = _repository.Delete(id);

            if (!task.IsCompletedSuccessfully)
            {
                return Results.UnprocessableEntity();
            }

            try
            {
                await _repository.Save();
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.UnprocessableEntity();
            }
        }

        public async Task<IResult> GetAll()
        {
            List<Cart> carts = _repository.Get();

            if(carts == null || carts.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(carts);
        }

        public async Task<IResult> GetById(string id)
        {
            Cart cart = _repository.GetById(id);

            if (cart == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(cart);
        }
        
        public async Task<IResult> GetByCustomrId(string id)
        {
            List<Cart> carts = _repository.Get(x => x.CustomerId == id);

            if (carts == null || carts.Count == 0)
            {
                return Results.NoContent();
            }

            List<GetListCartResponse> responses = _mapper.Map<List<GetListCartResponse>>(carts);

            foreach (var item in responses)
            {
                item.Variant.Product = _mapper.Map<GetListCartProductResponse>(_unitOfWork.productRepository.GetById(item.Variant.ProductId));
            }

            return Results.Ok(responses);
        }

        public async Task<IResult> Update(string id, Cart entity)
        {
            Cart updatedCart = _repository.Update(id, entity);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedCart);
        }
    }
}
