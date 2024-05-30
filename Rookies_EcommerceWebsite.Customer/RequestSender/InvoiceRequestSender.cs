using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public class InvoiceRequestSender : IInvoiceRequestSender
    {
        private readonly string _baseURL = "https://localhost:7144/api/";

        public InvoiceRequestSender()
        {
        }
        public async Task<Invoice> Create(Invoice entity)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.PostAsJsonAsync("Invoice", entity);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<Invoice>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }

        public async Task<Invoice> GetDetail(string id)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync($"Invoice/{id}");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<Invoice>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }

        public async Task<List<Invoice>> GetList()
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync("Invoice");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<List<Invoice>>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }

        public async Task<string> GetPaymentLink(VnPayLinkRequestModel entity)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.PostAsJsonAsync("VnPay", entity);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<string>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }
    }
}
