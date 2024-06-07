using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class RatingService 
    {
        private readonly IRepository<Rating> _repository;
        public RatingService(IRepository<Rating> repository)
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Rating entity)
        {
            Rating createdRating = await _repository.Create(entity);
            Task task = _repository.Save();
            task.Wait();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdRating);
        }

        public async Task<IResult> Delete(string id)
        {
            return Results.NotFound();
        }

        public async Task<IResult> GetAll()
        {
            return Results.Unauthorized();
        }

        public async Task<IResult> GetById(string id)
        {
            Rating variant = await _repository.GetById(id);

            if (variant == null)
            {
                return Results.NotFound(id);
            }

            return Results.Ok(variant);
        }

        public async Task<IResult> Update(string id, Rating entity)
        {
            Rating updatedRating = await _repository.Update(id, entity);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedRating);
        }
    }
}
