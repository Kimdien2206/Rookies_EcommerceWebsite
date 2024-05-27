using Dtos;
using Newtonsoft.Json;
using Rookies_EcommerceWebsite.Customer.Models;
using System.IO;
using System.Net.Http.Headers;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public class AuthRequestSender : IAuthRequestSender
    {
        private readonly string _baseURL = "https://localhost:7144/api/Auth/";

        public AuthRequestSender() 
        {
        }

        public async Task<UserInfo> Login(string username, string password)
        {
            HttpClient _httpClient = new HttpClient();
            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            LoginRequestDto dto = new LoginRequestDto()
            {
                UserName = username,
                Password = password
            };
            HttpResponseMessage Res = await _httpClient.PostAsJsonAsync("login", dto);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<UserInfo>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        } 
        
        public async Task<UserToken> GetToken(string username, string password)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            LoginRequestDto dto = new LoginRequestDto()
            {
                UserName = username,
                Password = password
            };
            HttpResponseMessage Res = await _httpClient.PostAsJsonAsync("GetToken", dto);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<UserToken>(EmpResponse);
            }
            //returning the employee list to view

            return null;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> SignUp(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfo> GetUserInfo(string id, string token)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri("https://localhost:7144/api/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync($"User/{id}");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<UserInfo>(EmpResponse);
            }
            //returning the employee list to view

            return null;
        }
    }
}
