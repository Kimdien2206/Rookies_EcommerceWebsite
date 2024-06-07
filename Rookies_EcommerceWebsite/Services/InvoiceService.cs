using AutoMapper;
using Dtos;
using Dtos.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Rookies_EcommerceWebsite.API.Interfaces;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Data.Enum;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;

namespace Rookies_EcommerceWebsite.Services
{
    public class InvoiceService
    {
        private readonly IRepository<Invoice> _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> repository, UnitOfWork unitOfWork, IMapper mapper)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IResult> Create(CreateInvoiceRequestDto requestDto)
        {
            Invoice entity = _mapper.Map<Invoice>(requestDto);
            if(entity == null)
            {
                return Results.BadRequest();
            }

            Invoice invoice = await _unitOfWork.invoiceRepository.Create(entity);
            if (invoice == null)
            {
                return Results.UnprocessableEntity();
            }

            foreach (InvoiceVariant invoiceVariant in invoice.InvoiceVariants)
            {
                Variant variant = _unitOfWork.variantRepository.GetById(invoiceVariant.VariantID);  
                
                if(invoiceVariant.Amount <= variant.Stock)
                {
                    variant.Stock -= invoiceVariant.Amount;
                }
                else
                {
                    return Results.UnprocessableEntity();
                }


                Product product = _unitOfWork.productRepository.GetById(variant.ProductId);
                
                if(product == null)
                {
                    return Results.NotFound();
                }

                invoiceVariant.Price = (ulong)product.Price;
                invoiceVariant.TotalCost = (ulong)product.Price * invoiceVariant.Amount;
                invoice.TotalCost += (ulong)product.Price;
            }

            foreach(InvoiceVariantDto item in requestDto.InvoiceVariants)
            {
                await _unitOfWork.cartRepository.Delete(item.CartId);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return Results.Ok(invoice);
                
            }
            catch (Exception ex)
            {
                return Results.UnprocessableEntity(ex);
            }
        }

        public async Task<IResult> Delete(string id)
        {
            return Results.NotFound();
        }

        public async Task<IResult> GetAll()
        {
            List<Invoice> invoices = _repository.Get();

            if (invoices == null || invoices.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(invoices);
        }

        public async Task<IResult> GetPaidInvoice()
        {
            List<Invoice> invoices = _repository.Get(x => x.Status == InvoiceStatus.Paid);

            if (invoices == null || invoices.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(invoices);
        } 
        
        public async Task<IResult> GetUnpaidInvoice()
        {
            List<Invoice> invoices = _repository.Get(x => x.Status == InvoiceStatus.Unpaid);

            if (invoices == null || invoices.Count == 0)
            {
                return Results.NoContent();
            }

            return Results.Ok(invoices);
        }

        public async Task<IResult> GetById(string id)
        {
            Invoice invoice = _repository.GetById(id);

            if (invoice == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(invoice);
        }

        public async Task<IResult> Update(string id, Invoice entity)
        {
            if (entity.Status == InvoiceStatus.Canceled)
            {
                Invoice updatedInvoice = await _unitOfWork.invoiceRepository.Update(id, entity);
                Invoice invoiceWithVariant = await _unitOfWork.invoiceRepository.GetById(id);
                foreach (InvoiceVariant invoiceVariant in invoiceWithVariant.InvoiceVariants)
                {
                    Variant variant = invoiceVariant.Variant;
                    
                    variant.Stock += invoiceVariant.Amount;
                    invoiceVariant.Amount = 0; 
                }

                try
                {
                    _unitOfWork.SaveChanges();
                    return Results.Ok(updatedInvoice);
                }
                catch (Exception ex)
                {
                    return Results.UnprocessableEntity(ex);
                }
            }
            else
            {
                Invoice updatedInvoice = _repository.Update(id, entity);
                Task task = _repository.Save();

                if (!task.IsCompleted)
                {
                    return Results.UnprocessableEntity();
                }
                return Results.Ok(updatedInvoice);
            }
        }
    }
}
