﻿using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Services;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _service;
        private readonly IMapper _mapper;

        public InvoiceController(InvoiceService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetById(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateInvoiceRequestDto requestDto)
        {
            return await _service.Create(requestDto);
        }

        [HttpPatch]
        [Route("{id}")]
        [Authorize]
        public async Task<IResult> UpdateStatus(string id, [FromBody] UpdateInvoiceRequestDto updateInvoiceRequestDto)
        {
            Invoice updateInvoice = _mapper.Map<Invoice>(updateInvoiceRequestDto);
            return await _service.Update(id, updateInvoice);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
