using Dtos;
using Rookies_EcommerceWebsite.Customer.Clients;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class InvoiceService
    {
        private readonly IInvoicesClient _invoicesClient;
        public InvoiceService(IInvoicesClient invoicesClient) 
        {
            this._invoicesClient = invoicesClient;
        }

        public async Task<Invoice> Create(InvoiceViewModel invoice) 
        {
            List<InvoiceVariantDto> variants = new List<InvoiceVariantDto>();
            foreach (CreateInvoiceVariant item in invoice.invoiceVariants)
            {

                variants.Add(new InvoiceVariantDto()
                {
                    Amount = item.Amount,
                    VariantId = item.VariantID,
                    CartId = item.CartId,
                });
            }
            CreateInvoiceRequestDto newInvoice = new CreateInvoiceRequestDto()
            {
                Name = invoice.Name,
                PhoneNumber = invoice.PhoneNumber,
                Address = invoice.Address,
                Email = invoice.Email,
                InvoiceVariants = variants,
                CustomerId = invoice.CustomerId
            };
            return await _invoicesClient.CreateNewInvoice(newInvoice);
        }

        public async Task<string> GetPaymentLink(VnPayLinkRequestModel model)
        {
            return await _invoicesClient.CreatePaymentLink(model);
        }
    }
}
