using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using System.Threading.Tasks;

namespace Rookies_EcommerceWebsite.Services
{
    public class VariantService : IService<Variant>
    {
        private readonly IRepository<Variant> _repository;
        public VariantService(IRepository<Variant> repository) 
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Variant entity)
        {
            Variant createdVariant = await _repository.Insert(entity);
            Task task = _repository.Save();

            if(!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(createdVariant);
        }

        public async Task<IResult> Delete(string id)
        {
            await _repository.Delete(id);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.NotFound();
            }

            return Results.Ok();
        }

        public async Task<IResult> GetAll()
        {
            return Results.Unauthorized();
        }

        public async Task<IResult> GetById(string id)
        {
            Variant variant = await _repository.GetById(id);

            if(variant == null)
            {
                return Results.NotFound(id);
            }

            return Results.Ok(variant);
        }

        public async Task<IResult> Update(string id, Variant entity)
        {
            Variant updatedVariant = await _repository.Update(id, entity);
            Task task = _repository.Save();

            if(!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedVariant);
        }
    }
}
