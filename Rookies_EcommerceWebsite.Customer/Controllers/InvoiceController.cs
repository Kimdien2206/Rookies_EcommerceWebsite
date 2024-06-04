﻿using Dtos.Response;
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


        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel invoiceViewModel)
        {
            if (ModelState.IsValid || invoiceViewModel.invoiceVariants.Count != 0)
            {
                Invoice createdInvoice = await _invoiceService.Create(invoiceViewModel);
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
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
