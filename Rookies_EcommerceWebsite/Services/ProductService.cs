﻿using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Dtos;

namespace Rookies_EcommerceWebsite.Services
{
    public class ProductService : IService<Product>
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Product creatingProduct)
        {
            Product createdProduct = await _repository.Insert(creatingProduct);
            await _repository.Save();

            if (createdProduct == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdProduct);
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

        public async Task<IResult> GetById(string id)
        {
            Product product = await _repository.GetById(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }

        public async Task<IResult> GetAll()
        {
            List<Product> products = await _repository.GetAll();
            if (products == null || products.Count == 0)
            {
                return Results.NoContent();
            }
            return Results.Ok(products);
        }

        public async Task<IResult> Update(string id, Product updatingProduct)
        {
            Product updatedProduct = await _repository.Update(id, updatingProduct);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity(updatingProduct);
            }

            return Results.Ok(updatedProduct);
        }
    }
}
