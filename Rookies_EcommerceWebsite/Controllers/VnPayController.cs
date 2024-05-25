using AutoMapper;
using Azure;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Services;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly VnPayService vnPayService;
        private readonly IConfiguration configuration;

        public VnPayController() 
        {
            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            vnPayService = new VnPayService();
        }

        [HttpPost]
        public async Task<IResult> CreatePaymentUrl([FromBody] VnPayPaymentRequestDto requestDto) 
        {
            // GET ALL VNPAY CONFIG VARIABLE
            string apiURL = configuration["VNPay:ApiURL"];
            string version = configuration["VNPay:Version"];
            string command = configuration["VNPay:Command"];
            string tmnCode = configuration["VNPay:TmnCode"];
            string hashSecret = configuration["VNPay:HashSecret"];
            string bankCode = configuration["VNPay:BankCode"];
            string currCode = configuration["VNPay:CurrCode"];
            string locale = configuration["VNPay:Locale"];
            string orderType = configuration["VNPay:OrderType"];
            string returnUrl = configuration["VNPay:ReturnUrl"].ToString() + requestDto.InvoiceId;
            string defaultOrderInfor = configuration["VNPay:DefaultOrderInfor"];

            vnPayService.AddRequestData("vnp_Version", version);
            vnPayService.AddRequestData("vnp_Command", command);
            vnPayService.AddRequestData("vnp_TmnCode", tmnCode);
            vnPayService.AddRequestData("vnp_Amount", (requestDto.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            vnPayService.AddRequestData("vnp_CreateDate", requestDto.CreateDate.ToString("yyyyMMddHHmmss"));
            vnPayService.AddRequestData("vnp_CurrCode", currCode);
            vnPayService.AddRequestData("vnp_IpAddr", "127.0.0.1");
            vnPayService.AddRequestData("vnp_Locale", locale);
            vnPayService.AddRequestData("vnp_OrderInfo", defaultOrderInfor + requestDto.InvoiceId);
            vnPayService.AddRequestData("vnp_OrderType", orderType); //default value: other
            vnPayService.AddRequestData("vnp_ReturnUrl", returnUrl);
            vnPayService.AddRequestData("vnp_TxnRef", requestDto.InvoiceId); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            string paymentUrl = vnPayService.CreateRequestUrl(apiURL, hashSecret);

            return Results.Ok(paymentUrl);
        }



    }
}
