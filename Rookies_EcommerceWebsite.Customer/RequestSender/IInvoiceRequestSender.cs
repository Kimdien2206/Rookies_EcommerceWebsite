using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public interface IInvoiceRequestSender
    {
        Task<List<Invoice>> GetList();
        Task<Invoice> GetDetail(string id);
        Task<string> GetPaymentLink(VnPayLinkRequestModel entity);
        Task<Invoice> Create(Invoice entity);
    }
}
