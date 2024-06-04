using Dtos;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;

namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRequestSender _requestSender;
        public InvoiceService(IInvoiceRequestSender requestSender) 
        {
            this._requestSender = requestSender;
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
            };
            return await _requestSender.Create(newInvoice);
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
