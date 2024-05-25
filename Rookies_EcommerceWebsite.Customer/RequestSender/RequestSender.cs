
using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public class RequestSender<T> : IRequestSender<T> where T : class
    {
        private readonly string _baseURL = "https://localhost:7144/api/";

        public RequestSender() {
        }
        public async Task<List<T>> GetList(string path)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync(path);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<List<T>>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }
        public async Task<T> GetDetail(string path, string id)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync($"{path}/{id}");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<T>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }

        public async Task<T> Create(string path, T entity)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.PostAsJsonAsync<T>(path, entity);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<T>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }
    }
}
