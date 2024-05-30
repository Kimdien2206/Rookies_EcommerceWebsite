using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRequestSender _requestSender;
        public InvoiceService(IInvoiceRequestSender requestSender) 
        {
            this._requestSender = requestSender;
        }

        public async Task<Invoice> Create(Invoice invoice) 
        {
            return await _requestSender.Create(invoice);
        }
        public async Task<List<Invoice>> GetList()
        {
            return await _requestSender.GetList();
        }
        public async Task<Invoice> GetDetail(string id)
        {
            return await _requestSender.GetDetail(id);
        }
        public async Task<string> GetPaymentLink(VnPayLinkRequestModel model)
        {
            return await _requestSender.GetPaymentLink(model);
        }
    }
}
