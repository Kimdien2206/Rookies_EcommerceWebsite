using Dtos;
using Refit;
using Rookies_EcommerceWebsite.Customer.Models;

namespace Rookies_EcommerceWebsite.Customer.Clients
{
    public interface IInvoicesClient
    {
        [Post("/Invoice")]
        Task<Invoice> CreateNewInvoice([Body] CreateInvoiceRequestDto requestDto);
        
        [Post("/VnPay")]
        Task<string> CreatePaymentLink([Body] VnPayLinkRequestModel requestDto);
    }
}
