using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.Models.ViewModels;
using Rookies_EcommerceWebsite.Customer.Services;

namespace Rookies_EcommerceWebsite.Customer.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel invoiceViewModel)
        {
            List<InvoiceVariant> variants = new List<InvoiceVariant>();
            foreach(CreateInvoiceVariant item in invoiceViewModel.invoiceVariants)
            {
                
                variants.Add(new InvoiceVariant() 
                { 
                    Amount = item.Amount,
                    VariantID = item.VariantID,

                });
            }
            Invoice newInvoice = new Invoice()
            {
                Name = invoiceViewModel.Name,
                PhoneNumber = invoiceViewModel.PhoneNumber,
                Address = invoiceViewModel.Address,
                Email = invoiceViewModel.Email,
                InvoiceVariants = variants,
            };
            Invoice createdInvoice = await _invoiceService.Create(newInvoice);
            if (createdInvoice != null)
            {
                VnPayLinkRequestModel requestModel = new VnPayLinkRequestModel()
                {
                    InvoiceId = createdInvoice.Id,
                    Amount = createdInvoice.TotalCost,
                    CreateDate = createdInvoice.CreatedDate,
                };
                string link = await _invoiceService.GetPaymentLink(requestModel);

                return Redirect(link);
            }
            return BadRequest();
        }
    }
}
