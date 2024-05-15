using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Services
{
    public class InvoiceService : IService<Invoice>
    {
        private readonly IRepository<Invoice> _repository;

        public InvoiceService(IRepository<Invoice> repository)
        {
            this._repository = repository;
        }

        public async Task<IResult> Create(Invoice entity)
        {
            Invoice invoice = await _repository.Create(entity);
            await _repository.Save();

            if (invoice == null)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(invoice);
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
            List<Invoice> invoices = await _repository.GetAll();

            if (invoices == null || invoices.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(invoices);
        }

        public async Task<IResult> GetById(string id)
        {
            Invoice invoice = await _repository.GetById(id);

            if (invoice == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(invoice);
        }

        public async Task<IResult> Update(string id, Invoice entity)
        {
            Invoice updatedInvoice = await _repository.Update(id, entity);
            Task task = _repository.Save();

            if (!task.IsCompleted)
            {
                return Results.UnprocessableEntity();
            }

            return Results.Ok(updatedInvoice);
        }
    }
}
