using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class InvoiceService
    {
        private readonly IRequestSender<Invoice> _requestSender;
        public InvoiceService(IRequestSender<Invoice> requestSender) 
        {
            this._requestSender = requestSender;
        }

        public void Create(Invoice invoice) 
        { 
            
        }
    }
}
