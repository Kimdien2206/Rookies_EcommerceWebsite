using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.API.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAll();
        Task<List<Invoice>> GetPaidInvoice();
        Task<List<Invoice>> GetUnpaidInvoice();
        Task<Invoice> Create(Invoice entity);
        Task<Invoice> Update(string id, Invoice entity);
        Task Delete(string id);
        Task<Invoice> GetById(string id);
        Task Save();
    }
}
